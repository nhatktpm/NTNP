using NTNP.AppServices.AuthServices.Dtos.Request;
using NTNP.AppServices.AuthServices.Dtos.Response;

namespace NTNP.AppServices.AuthServices
{
    public interface IAuthAppService
    {
        public Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
    }
}
