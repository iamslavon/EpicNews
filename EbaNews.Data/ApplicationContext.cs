using EbaNews.Core.Entities;
using EbaNews.Core.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace EbaNews.Data
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext() : base("connectionString") { }

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }

        public DbSet<News> News { get; set; }

        public DbSet<SuggestedNews> SuggestedNews { get; set; }

        public DbSet<Language> Languages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
                .ToTable("Users", "dbo");
            modelBuilder.Entity<IdentityRole>()
                .ToTable("Roles", "dbo");
            modelBuilder.Entity<IdentityUserLogin>()
                .ToTable("Logins", "dbo");
            modelBuilder.Entity<IdentityUserClaim>()
                .ToTable("Claims", "dbo");
            modelBuilder.Entity<IdentityUserRole>()
                .ToTable("UserRoles", "dbo");
        }
    }
}
