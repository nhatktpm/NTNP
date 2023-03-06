using AutoMapper;
using Microsoft.AspNetCore.Http.Features;
using NLog;
using NTNP.Infratructure.Interfaces;

namespace NTNP.AppServices.BaseAppServices
{
    public class BaseAppService : IBaseAppService
    {
        protected IUnitOfWork _unitOfWork;
        protected NLog.ILogger _logger;
        protected readonly IMapper _mapper;

        public BaseAppService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = LogManager.GetCurrentClassLogger();
        }
    }
}
