using Microsoft.EntityFrameworkCore;
using Profile_Service.DataAccess;
using Profile_Service.Entities;
using Profile_Service.Models;
using Profile_Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Profile_Service.Services
{
    public class ProfileService : IProfileService
    {

        private readonly ProfileDbContext _context;

        public ProfileService(ProfileDbContext context)
        {
            _context = context;
        }

        public bool create(Profile profile)
        {
            bool result;
            try
            {
                using (var context = _context)
                {
                    context.Profiles.Add(profile);
                    context.SaveChanges();
                }
                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                result = false;
            }

            return result;
        }

        public int getProfileID(int accountID)
        {
            int id = 0;
            try
            {
                using (var context = _context)
                {
                    id = _context.Profiles
                        .Single(p => p.accountID == accountID).ID;

                }
                return id;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return id;
            }
        }

        public ProfileModel getByAccountID(int accountID)
        {
            ProfileModel profileModel;
            try
            {
                
                Profile profile = _context.Profiles
                        .FirstOrDefault(p => p.accountID == accountID);

                profileModel = new ProfileModel
                {
                    ID = profile.ID,
                    profileName = profile.profileName,
                    userTag = profile.userTag,
                    bio = profile.bio,
                };

                
                profileModel.followers = getFollowers(profile.ID);
                profileModel.following = getFollowing(profile.ID);


                return profileModel;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public List<Profile> getFollowers(int profileID)
        {
            List<Profile> followers = new List<Profile>();
            try
            {

                List<int> followerIDs = _context.Follows.Where(f => f.followingID == profileID).Select(f => f.followerID).ToList();

                foreach(int id in followerIDs)
                {
                    Profile profile = _context.Profiles.FirstOrDefault(p => p.ID == id);
                    profile.accountID = 0;
                    profile.bio = null;

                    followers.Add(profile);
                }

                return followers;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return followers;
            }
        }

        public List<Profile> getFollowing(int profileID)
        {
            List<Profile> following = new List<Profile>();
            try
            {

                List<int> followingIDs = _context.Follows.Where(f => f.followerID == profileID).Select(f => f.followingID).ToList();

                foreach (int id in followingIDs)
                {
                    Profile profile = _context.Profiles.FirstOrDefault(p => p.ID == id);

                    following.Add(profile);
                }

                return following;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return following;
            }
        }

        public Profile getByProfileName(string profileName)
        {
            Profile profile;
            try
            {
                using (var context = _context)
                {
                    profile = _context.Profiles
                        .Single(p => p.profileName == profileName);

                }
                return profile;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public bool checkUserTag(string userTag)
        {
            bool result;
            try
            {
                using (var context = _context)
                {
                    result = _context.Profiles.Any(p => p.userTag == userTag);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return result = false;
            }

            return result;
        }

        public bool update(Profile profile)
        {
            bool result;

            try
            {
                using (var context = _context)
                {
                    var prof = _context.Profiles
                        .Single(p => p.ID == profile.ID);
                    
                    prof.profileName = profile.profileName;
                    prof.userTag = profile.userTag;
                    prof.bio = profile.bio;
                    context.SaveChanges();
                }

                result = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                result = false;
            }

            return result;
        }

        public bool delete(Profile profile)
        {
            bool result;

            try
            {
                using (var context = _context)
                {
                    var prof = _context.Profiles
                        .Single(p => p.ID == profile.ID && p.accountID == profile.accountID );

                    context.Profiles.Remove(prof);
                    context.SaveChanges();
                }
                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                result = false;
            }

            return result;
        }
    }
}
