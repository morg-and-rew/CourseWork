using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace CourseWork.Data.Models
{
    public class ShopGame
    {
        private readonly AppDBContent _appDbContext;

        private const string SessionGameIdKey = "GameId";

        public ShopGame(AppDBContent appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public string ShopGamesId { get; set; }

        public List<ShopGamesItem> ListShopItems { get; set; }

        public static ShopGame GetGames(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            AppDBContent context = services.GetService<AppDBContent>();

            string shopGameId = session.GetString(SessionGameIdKey) ?? Guid.NewGuid().ToString();

            session.SetString(SessionGameIdKey, shopGameId);

            return new ShopGame(context) { ShopGamesId = shopGameId };
        }

        public void AddToGame(Game game)
        {
            ShopGamesItem newItem = new ShopGamesItem
            {
                ShopGamesId = ShopGamesId,
                Game = game,
                Price = game.Price
            };

            _appDbContext.ShopGamesItem.Add(newItem);
            _appDbContext.SaveChanges();
        }

        public List<ShopGamesItem> GetShopItems()
        {
            List<ShopGamesItem> shopItems = _appDbContext.ShopGamesItem
                .Where(item => item.ShopGamesId == ShopGamesId)
                .Include(item => item.Game)
                .ToList();

            return shopItems;
        }
    }
}