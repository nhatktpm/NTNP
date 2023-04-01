using Microsoft.AspNetCore.Mvc;
using NTNP.AppServices.AuthServices;
using NTNP.AppServices.AuthServices.Dtos.Request;

namespace NTNP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthAppService _authAppService;

        public AuthController(IAuthAppService authAppService)
        {
            _authAppService = authAppService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            try
            {
                var result = await _authAppService.Login(loginRequestDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);

                return BadRequest(ex.Message);
            }
        }
    }
}
