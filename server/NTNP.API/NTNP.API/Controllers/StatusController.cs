using Microsoft.AspNetCore.Mvc;

namespace NTNP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : BaseController
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Ok");
        }
    }
}
