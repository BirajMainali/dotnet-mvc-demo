using Microsoft.AspNetCore.Mvc;

namespace MvcDemo.Areas.User.Controller
{
    [Area("User")]
    public class UserController : Microsoft.AspNetCore.Mvc.Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}