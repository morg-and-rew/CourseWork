using CourseWork.Data.Interface;
using CourseWork.Data.Models;
using CourseWork.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CourseWork.Controllers
{
    public class ShopGameController : ShopGameBaseController
    {
        private const string IndexAction = "Index";

        public ShopGameController(IAllGame gameRep, ShopGame shopGame)
            : base(gameRep ?? throw new ArgumentNullException(nameof(gameRep)),
                   shopGame ?? throw new ArgumentNullException(nameof(shopGame)))
        {
        }

        public ViewResult Index()
        {
            if (_shopGame == null)
            {
                throw new InvalidOperationException("ShopGame is null.");
            }

            List<ShopGamesItem> items = _shopGame.GetShopItems() ?? throw new InvalidOperationException("GetShopItems returned null.");
            _shopGame.ListShopItems = items;

            ShopGameViewModel viewModel = new ShopGameViewModel
            {
                ShopGame = _shopGame
            };

            return View(viewModel);
        }

        public RedirectToActionResult AddToGame(int id)
        {
            if (_gameRep == null || _gameRep.Games == null)
            {
                throw new InvalidOperationException("Game repository or its Games collection is null.");
            }

            Game game = _gameRep.Games.FirstOrDefault(game => game?.Id == id);

            if (game != null)
            {
                _shopGame?.AddToGame(game);
            }

            return RedirectToAction(IndexAction);
        }
    }
}