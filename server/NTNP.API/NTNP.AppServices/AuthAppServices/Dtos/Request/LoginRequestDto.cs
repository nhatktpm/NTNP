﻿namespace NTNP.AppServices.AuthServices.Dtos.Request
{
    public class LoginRequestDto
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
