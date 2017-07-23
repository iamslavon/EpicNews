using Microsoft.AspNet.Identity.EntityFramework;

namespace EbaNews.Core.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() { }

        public ApplicationUser(string name, string email, string password)
        {
            UserName = name;
            Email = email;
            PasswordHash = password;
        }
    }
}
