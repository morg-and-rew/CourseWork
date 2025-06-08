using CourseWork.Data.Interface;
using CourseWork.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseWork.Data.Repository
{
    public class OrdersRepository : BaseRepository, IAllOrders
    {
        private readonly ShopGame _shopGame;

        public OrdersRepository(AppDBContent appDbContext, ShopGame shopGame)
            : base(appDbContext ?? throw new ArgumentNullException(nameof(appDbContext)))
        {
            _shopGame = shopGame ?? throw new ArgumentNullException(nameof(shopGame));
        }

        public void CreateOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order), "Order cannot be null.");
            }

            try
            {
                order.OrderTime = DateTime.Now;

                _appDbContext.Order.Add(order ?? throw new InvalidOperationException("Order is null."));

                _appDbContext.SaveChanges();

                if (order.Id == 0)
                {
                    throw new InvalidOperationException("Order ID was not generated.");
                }

                List<ShopGamesItem> items = _shopGame.ListShopItems ?? throw new InvalidOperationException("ShopGame items list is null.");

                foreach (ShopGamesItem element in items)
                {
                    if (element?.Game == null)
                    {
                        throw new InvalidOperationException("ShopGamesItem or its Game is null.");
                    }

                    OrderDetail orderDetail = new OrderDetail
                    {
                        GameID = element.Game.Id,
                        OrderID = order.Id,
                        Price = (uint)element.Game.Price
                    };

                    _appDbContext.OrderDetail.Add(orderDetail ?? throw new InvalidOperationException("OrderDetail is null."));
                }

                _appDbContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Error saving order: {ex.Message}");
                Console.WriteLine($"Inner exception: {ex.InnerException?.Message}");
                throw;
            }
        }
    }
}