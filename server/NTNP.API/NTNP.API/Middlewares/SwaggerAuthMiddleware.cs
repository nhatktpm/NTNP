using System.Net;
using System.Text;

namespace NTNP.API.Middlewares
{
    public class SwaggerAuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Swagger Authentication Middleware Contructor
        /// </summary>
        public SwaggerAuthMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        /// <summary>
        /// Handle when the user access the static file but it does not found
        /// </summary>
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                string path = httpContext.Request.Path.Value;
                if (!path.StartsWith("/swagger/index.html")
                    && !path.StartsWith("/swagger/v1/swagger.json")
                    && path.Trim() != "/swagger")
                {
                    await _next(httpContext);
                }
                else
                {
                    string authHeader = httpContext.Request.Headers["Authorization"].ToString();
                    if (authHeader?.StartsWith("Basic") == true)
                    {
                        string encodedUsernamePassword = authHeader["Basic ".Length..].Trim();
                        Encoding encoding = Encoding.GetEncoding("iso-8859-1");
                        string usernamePassword = encoding.GetString(Convert.FromBase64String(encodedUsernamePassword));

                        int seperatorIndex = usernamePassword.IndexOf(':');

                        string username = usernamePassword[..seperatorIndex];
                        string password = usernamePassword[(seperatorIndex + 1)..];
                        string usernameAuth = _configuration.GetValue<string>("SwaggerAuthMiddleware:Username");
                        string passwordAuth = _configuration.GetValue<string>("SwaggerAuthMiddleware:Password");
                        if (username.Trim() == usernameAuth && password.Trim() == passwordAuth)
                        {
                            await _next(httpContext);
                            return;
                        }
                    }
                    httpContext.Response.Headers["WWW-Authenticate"] = "Basic";
                    httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                }
            }
            catch (Exception)
            {
                await _next(httpContext);
            }
        }
    }
}
