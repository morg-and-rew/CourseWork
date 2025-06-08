using CourseWork.Data.Interface;
using CourseWork.Data.Models;
using CourseWork.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CourseWork.Controllers
{
    public class GamesController : BaseController
    {
        private readonly IGameCategory _gameCategory;

        private const string ActionGameCategory = "ActionGame";
        private const string RolePlayingGamesCategory = "Role-playingGames";
        private const string ActionGameDisplayName = "Экшен";
        private const string RolePlayingGamesDisplayName = "Ролевые игры";

        public GamesController(IAllGame gameRep, IGameCategory gameCategory)
            : base(gameRep)
        {
            _gameCategory = gameCategory ?? throw new ArgumentNullException(nameof(gameCategory));
        }

        [Route("Games/List")]
        [Route("Games/List/{category}")]
        public ViewResult List(string category)
        {
            string currentCategory = string.Empty;
            IEnumerable<Game> games = null;

            if (_gameRep == null || _gameRep.Games == null)
            {
                throw new InvalidOperationException("Game repository or its Games collection is null.");
            }

            if (string.IsNullOrEmpty(category))
            {
                games = _gameRep.Games.OrderBy(game => game?.Id);
            }
            else
            {
                if (string.Equals(ActionGameCategory, category, StringComparison.OrdinalIgnoreCase))
                {
                    games = _gameRep.Games
                        .Where(game => game?.Category?.CategoryName != null &&
                                       game.Category.CategoryName.Equals(ActionGameDisplayName, StringComparison.OrdinalIgnoreCase))
                        .OrderBy(game => game?.Id);
                }
                else if (string.Equals(RolePlayingGamesCategory, category, StringComparison.OrdinalIgnoreCase))
                {
                    games = _gameRep.Games
                        .Where(game => game?.Category?.CategoryName != null &&
                                       game.Category.CategoryName.Equals(RolePlayingGamesDisplayName, StringComparison.OrdinalIgnoreCase))
                        .OrderBy(game => game?.Id);
                }

                currentCategory = category;
            }

            GamesListViewModel viewModel = new GamesListViewModel
            {
                AllGames = games ?? Enumerable.Empty<Game>(),
                CurrentCategory = currentCategory
            };

            ViewBag.Title = "Страница с играми";

            return View(viewModel);
        }
    }
}