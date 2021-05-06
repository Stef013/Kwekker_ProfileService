using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Profile_Service.Entities;

namespace Profile_Service.DataAccess
{
    public class ProfileDbContext : DbContext
    {
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Follows> Follows { get; set; }

        public ProfileDbContext(DbContextOptions<ProfileDbContext> options) : base(options)
        {
        }
    }
}
