using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Profile_Service.Entities
{
    
    public class Follows
    {
        public int ID { get; set; }
        public int followerID { get; set; }
        public int followingID { get; set; } 
    }
}
