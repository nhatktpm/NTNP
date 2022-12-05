using Microsoft.AspNetCore.Mvc;

namespace NTNP.API.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}