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

        //public DbSet<Person> People { get; set; }
    }
}
