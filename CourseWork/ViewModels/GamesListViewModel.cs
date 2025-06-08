using CourseWork.Data.Models;

namespace CourseWork.ViewModels
{
    public class GamesListViewModel
    {
        public IEnumerable<Game> AllGames { get; set; }

        public string CurrentCategory { get; set; }
    }
}
