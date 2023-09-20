using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Personalportfolio.Models;

namespace Personalportfolio.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }

        public DbSet<User> Users { get; set; }

        public DbSet<SocialMedia> SocialMedia { get; set; }

        public DbSet<Interest> Interests { get; set; }

        public DbSet<Tools> Tools { get; set; }

        public DbSet<Awards> Awards { get; set; }

        public DbSet<WorkFlow> WorkFlows { get; set; }

        public DbSet<Education> Educations { get; set; }

        public DbSet<Experience> Experiences { get; set; }

         public DbSet<Title> Titles { get; set; }

        public DbSet<Account> Accounts { get; set; }
    }
}
