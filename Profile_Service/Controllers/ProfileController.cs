using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Profile_Service.Entities;
using Profile_Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Profile_Service.DataAccess;
using Profile_Service.Models;

namespace Profile_Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly ILogger<ProfileController> _logger;
        private ProfileService profileService;

        public ProfileController(ProfileDbContext context, ILogger<ProfileController> logger)
        {
            profileService = new ProfileService(context);
            _logger = logger;
        }

        [HttpPost]
        public string create([FromBody] Profile profile)
        {
            if (String.IsNullOrEmpty(profile.profileName) || String.IsNullOrEmpty(profile.userTag) || profile.accountID == 0)
            {
                return "Certain field are empty.";
            }
            else
            {
                if (profileService.create(profile))
                {
                    return "Success!";
                }
                else
                {
                    return "Database error!";
                }
            }
        }
        
        [HttpGet("profileid")]
        public int getProfileId(int accountID)
        {
            return profileService.getProfileID(accountID);
        }

        [HttpGet("account")]
        public ProfileModel getByAccountID(int accountID)
        {
            return profileService.getByAccountID(accountID);
        }

        [HttpGet("name")]
        public Profile getByProfileName(string profileName)
        {
            return profileService.getByProfileName(profileName);
        }

        [HttpGet("userTag")]
        public bool checkUserTag( string usertag)
        {
            return profileService.checkUserTag(usertag);
        }

        [HttpPut]
        public bool update([FromBody] Profile profile)
        {
            return profileService.update(profile);
        }

        [HttpDelete]
        public bool delete([FromBody] Profile profile)
        {
            return profileService.create(profile);
        }
    }
}
