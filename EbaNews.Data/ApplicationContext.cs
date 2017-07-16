using EbaNews.Core.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EbaNews.Data
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext() : base("connectionString") { }

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }

        //public DbSet<Person> People { get; set; }
    }
}
