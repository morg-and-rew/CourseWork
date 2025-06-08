using CourseWork.Data.Interface;
using CourseWork.Data.Models;

namespace CourseWork.Controllers
{
    public abstract class ShopGameBaseController : BaseController
    {
        protected readonly ShopGame _shopGame;

        protected ShopGameBaseController(IAllGame gameRep, ShopGame shopGame)
            : base(gameRep ?? throw new ArgumentNullException(nameof(gameRep)))
        {
            _shopGame = shopGame ?? throw new ArgumentNullException(nameof(shopGame));
        }
    }
}