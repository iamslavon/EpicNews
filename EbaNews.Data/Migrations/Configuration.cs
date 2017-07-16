using EbaNews.Core.Entities;
using EbaNews.Core.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.Migrations;

namespace EbaNews.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationContext context)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var adminRole = new IdentityRole { Name = "admin" };
            var password = new PasswordHasher().HashPassword("1488");
            var admin = new ApplicationUser { Email = "admin@tkn.ua", UserName = "admin", PasswordHash = password };

            var createdUserResult = userManager.Create(admin);
            var createdRoleResult = roleManager.Create(adminRole);

            if (createdUserResult.Succeeded && createdRoleResult.Succeeded)
            {
                userManager.AddToRole(admin.Id, adminRole.Name);
            }
        }
    }
}
