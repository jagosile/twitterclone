using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Account
{
    public class LoginRequest : ILoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
