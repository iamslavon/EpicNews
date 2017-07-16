using EbaNews.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace EbaNews.Services.Membership
{
    public class ApplicationRoleManager : RoleManager<IdentityRole>
    {
        public ApplicationRoleManager(IRoleStore<IdentityRole, string> store) : base(store)
        {

        }

        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        {
            var db = context.Get<ApplicationContext>();
            ApplicationRoleManager manager = new ApplicationRoleManager(new RoleStore<IdentityRole>(db));
            return manager;
        }
    }
}
