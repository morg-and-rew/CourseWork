using CourseWork.Data.Models;

namespace CourseWork.Data.Interface
{
    public interface IGameCategory
    {
        IEnumerable<Category> AllCategories {  get; }
    }
}
