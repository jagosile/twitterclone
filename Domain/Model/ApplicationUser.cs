using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Model
{
    public class ApplicationUser 
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
