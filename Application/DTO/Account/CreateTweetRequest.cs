using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Account
{
    public class CreateTweetRequest 
    {
        public string Body { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        
    }
}
