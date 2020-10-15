using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class SubscriptionDTO 
    {
        public int Id { get; set; }
        public UserDTO Subscriber { get; set; }
        public DateTime Created { get; set; }

    }
}
