using CourseWork.Data.Models;

namespace CourseWork.Data.Interface
{
    public interface IAllGame
    {
        IEnumerable<Game> Games { get; }
        IEnumerable<Game> GetFavsGame { get; }
        Game getObjectsGame(int gameId);
    }
}
