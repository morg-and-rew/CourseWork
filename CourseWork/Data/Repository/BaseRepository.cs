using Microsoft.EntityFrameworkCore;

namespace CourseWork.Data.Repository
{
    public abstract class BaseRepository
    {
        protected readonly AppDBContent _appDbContext;

        protected BaseRepository(AppDBContent appDbContext)
        {
            _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }
    }
}