using Microsoft.AspNetCore.Mvc;

namespace NTNP.API.Controllers
{
    public class BaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
