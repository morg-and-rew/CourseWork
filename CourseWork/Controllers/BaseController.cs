using CourseWork.Data.Interface;
using CourseWork.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseWork.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly IAllGame _gameRep;

        protected BaseController(IAllGame gameRep)
        {
            if(gameRep != null) 
                _gameRep = gameRep;
        }
    }
}