using EbaNews.Core.Identity;

namespace EbaNews.Web.Areas.Admin.Models.Users
{
    public class UserViewModel
    {
        public UserViewModel() { }

        public UserViewModel(ApplicationUser user)
        {
            Id = user.Id;
            Name = user.UserName;
            Email = user.Email;
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
    }
}