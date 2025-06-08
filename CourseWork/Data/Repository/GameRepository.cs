using CourseWork.Data.Interface;
using CourseWork.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseWork.Data.Repository
{
    public class GameRepository : BaseRepository, IAllGame
    {
        public GameRepository(AppDBContent appDbContext)
            : base(appDbContext ?? throw new ArgumentNullException(nameof(appDbContext)))
        {
        }

        public IEnumerable<Game> Games => _appDbContext?.Games.Include(c => c.Category)
                                          ?? throw new InvalidOperationException("Games is null.");

        public IEnumerable<Game> GetFavsGame => _appDbContext?.Games
            .Where(p => p.IsFavorite)
            .Include(c => c.Category)
            ?? throw new InvalidOperationException("GetFavsGame is null.");

        public Game getObjectsGame(int gameId)
        {
            if (_appDbContext == null || _appDbContext.Games == null)
            {
                throw new InvalidOperationException("Game repository or its Games collection is null.");
            }

            return _appDbContext.Games.FirstOrDefault(p => p.Id == gameId);
        }
    }
}