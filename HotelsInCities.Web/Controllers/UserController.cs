using HotelsInCities.Application.Intefaces.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelsInCities.Web.Controllers
{

    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
