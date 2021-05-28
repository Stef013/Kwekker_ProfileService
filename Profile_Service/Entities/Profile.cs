using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Profile_Service.Entities
{
    public class Profile
    {
        [Key]
        public int ID { get; set; }
        public int accountID { get; set; }
        public string profileName { get; set; }
        public string userTag { get; set; }
        public string bio { get; set; }
    }
}
