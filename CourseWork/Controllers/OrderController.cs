using CourseWork.Data.Interface;
using CourseWork.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseWork.Controllers
{
    public class OrderController : ShopGameBaseController
    {
        private readonly IAllOrders _allOrders;

        public OrderController(IAllGame gameRep, ShopGame shopGame, IAllOrders allOrders)
            : base(gameRep, shopGame)
        {
            _allOrders = allOrders ?? throw new ArgumentNullException(nameof(allOrders));
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (_shopGame == null)
            {
                throw new InvalidOperationException("ShopGame is null.");
            }

            _shopGame.ListShopItems = _shopGame.GetShopItems() ?? throw new InvalidOperationException("GetShopItems returned null.");

            if (_shopGame.ListShopItems.Count == 0)
            {
                ModelState.AddModelError("", "У вас должны быть товары!");
            }

            if (ModelState.IsValid)
            {
                if (_allOrders == null)
                {
                    throw new InvalidOperationException("AllOrders is null.");
                }

            }

                _allOrders.CreateOrder(order ?? throw new ArgumentNullException(nameof(order)));
                return RedirectToAction("Complete");
           // return View(order);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ успешно обработан";
            return View();
        }
    }
}