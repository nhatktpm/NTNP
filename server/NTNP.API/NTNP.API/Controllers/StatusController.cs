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
            _logger.Error("test");
            return Ok("ádasda");
        }
    }
}
