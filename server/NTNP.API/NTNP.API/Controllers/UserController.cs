using Microsoft.AspNetCore.Mvc;
using NTNP.Infratructure.Interfaces;

namespace NTNP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Index(int id)
        {
            var data = _unitOfWork.UserRepository.Find(1);
            return Ok(id);
        }
    }
}