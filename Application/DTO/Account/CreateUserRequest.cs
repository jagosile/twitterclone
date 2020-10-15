using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Account
{
    public class CreateUserRequest : ILoginRequest, ICreateUserRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Biography { get; set; }
    }
}
