using CourseWork.Data.Interface;
using CourseWork.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseWork.Data.Repository
{
    public class CategoryRepository : BaseRepository, IGameCategory
    {
        public CategoryRepository(AppDBContent appDbContext)
            : base(appDbContext)
        {
        }

        public IEnumerable<Category> AllCategories => _appDbContext?.Categories ?? throw new InvalidOperationException("Categories is null.");
    }
}