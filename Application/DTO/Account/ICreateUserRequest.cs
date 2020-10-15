using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Account
{
    public interface ICreateUserRequest : ILoginRequest
    {
      public string Biography { get; set; }
    }
}
