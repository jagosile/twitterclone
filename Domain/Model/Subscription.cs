using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class Subscription
    {
        public int Id { get; set; }
        public IdentityUser Subscriber { get; set; }
        public IdentityUser IdentityUser { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;


    }
}
