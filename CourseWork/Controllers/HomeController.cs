using CourseWork.Data.Interface;
using CourseWork.Data.Models;
using CourseWork.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CourseWork.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IAllGame gameRep)
            : base(gameRep ?? throw new ArgumentNullException(nameof(gameRep)))
        {
        }

        public ViewResult Index()
        {
            if (_gameRep == null)
            {
                throw new InvalidOperationException("Game repository is null.");
            }

            HomeViewModel homeCars = new HomeViewModel
            {
                FavoriteGames = _gameRep.GetFavsGame ?? Enumerable.Empty<Game>()
            };

            return View(homeCars);
        }
    }
}