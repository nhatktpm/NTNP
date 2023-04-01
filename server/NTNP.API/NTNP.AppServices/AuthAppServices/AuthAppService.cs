using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using NTNP.AppServices.AuthAppServices.Constants;
using NTNP.AppServices.AuthServices.Dtos.Constants;
using NTNP.AppServices.AuthServices.Dtos.Request;
using NTNP.AppServices.AuthServices.Dtos.Response;
using NTNP.EFCore.Models.AppSettings;
using NTNP.Infratructure.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NTNP.AppServices.AuthServices
{
    public class AuthAppService : IAuthAppService
    {
        private readonly AppSetting _appSettings;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;

        public AuthAppService(IOptions<AppSetting> appSettings,
            IConfiguration configuration,
            IUnitOfWork unitOfWork)
        {
            _appSettings = appSettings.Value;
            _configuration = configuration;
            _unitOfWork = unitOfWork;
        }
        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            LoginResponseDto loginResponseDto = new LoginResponseDto();
            var user = await _unitOfWork.UserRepository.GetByUserName(loginRequestDto.UserName);
            if (user == null)
            {
                loginResponseDto.Error = LoginFailureErrors.LoginFail;
                loginResponseDto.Success = false;

                return loginResponseDto;
            }
            var secret = _appSettings.Secret;
            byte[] key = Encoding.ASCII.GetBytes(secret);
            var x = _configuration.GetValue<string>("Issuer");
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypesCustom.TimeZoneId, ""),
                    new Claim(ClaimTypes.Role, user.Role.ToString()),
                    new Claim(ClaimTypes.Email, "nhat.nguyen@gmail.com"),
                }),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Expires = DateTime.UtcNow.AddDays(1),
                Issuer = _configuration.GetValue<string>("Issuer"),
            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            loginResponseDto.Success= true;
            loginResponseDto.Token = tokenHandler.WriteToken(token);

            return loginResponseDto;
        }

        public string ReadJwtToken(string tokenStr)
        {
            var validClaimList = new List<string>(new string[] { "Name", "Role" });
            try
            {
                if (ValidateToken(tokenStr))
                {
                    var token = new JwtSecurityToken(jwtEncodedString: tokenStr);
                    return JsonConvert.SerializeObject(token.Claims.Where(claim => validClaimList.Contains(claim.Type))
                        .ToDictionary(claim => claim.Type, claim => claim.Value));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        private bool ValidateToken(string authToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = GetValidationParameters();

            SecurityToken validatedToken;
            tokenHandler.ValidateToken(authToken, validationParameters, out validatedToken);
            return true;
        }
        private TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters()
            {
                ValidateLifetime = true,
                LifetimeValidator = CustomLifetimeValidator,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Secret)),
                ValidateIssuerSigningKey = true,
                ValidateAudience = false,
                ValidateIssuer = false,
            };
        }

        // N Must have
        private bool CustomLifetimeValidator(DateTime? notBefore, DateTime? expires, SecurityToken tokenToValidate, TokenValidationParameters @param)
        {
            if (expires != null)
            {
                return expires > DateTime.UtcNow;
            }
            return false;
        }
    }
}
