using Microsoft.AspNetCore.Mvc;
using NLog;

namespace NTNP.API.Controllers
{
    public class BaseController : ControllerBase
    {
        protected NLog.ILogger _logger;
        public BaseController()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }
    }
}
