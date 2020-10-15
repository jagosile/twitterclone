using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class CreateTweetRequest 
    {
        public string Body { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        
    }
}
