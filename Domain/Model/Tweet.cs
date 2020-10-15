using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class Tweet
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime PostDate { get; set; }

        public IdentityUser IdentityUser { get; set; }

    }
}
