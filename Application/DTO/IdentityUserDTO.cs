using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class IdentityUserDTO
    {
        [Required(ErrorMessage = "Email is missing."), EmailAddress(ErrorMessage = "Email is not valid.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is missing.")]
        public string Password { get; set; }
    }
}
