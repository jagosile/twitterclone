using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class TweetDTO 
    {
        public int Id { get; set; }
        public UserDTO User { get; set; }
        public string Message { get; set; }
        public DateTime Created { get; set; }
        
    }
}
