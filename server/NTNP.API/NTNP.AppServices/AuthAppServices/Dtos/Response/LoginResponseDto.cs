namespace NTNP.AppServices.AuthServices.Dtos.Response
{
    public class LoginResponseDto
    {
        public string Error { get; set; }
        public bool Success { get; set; }
        public string Token { get; set; }
    }
}
