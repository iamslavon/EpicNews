using System.Collections.Generic;

namespace EbaNews.Web.Areas.Admin.Models.Users
{
    public class UserViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public IList<string> Roles { get; set; }
    }
}