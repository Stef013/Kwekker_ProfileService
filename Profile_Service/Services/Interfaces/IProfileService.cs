using Profile_Service.Entities;
using Profile_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Profile_Service.Services.Interfaces
{
    interface IProfileService
    {
        public bool create(Profile profile);
        public int getProfileID(int accountID);
        public ProfileModel getByAccountID(int accountID);
        public Profile getByProfileName(string profileName);
        public bool checkUserTag(string userTag);
        public bool update(Profile profile);
        public bool delete(Profile profile);
    }
}
