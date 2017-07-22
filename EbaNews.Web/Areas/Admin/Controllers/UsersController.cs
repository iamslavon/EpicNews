using EbaNews.Services.Membership;
using EbaNews.Web.Areas.Admin.Models.Users;
using Microsoft.AspNet.Identity.Owin;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EbaNews.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "owner")]
    public class UsersController : Controller
    {
        private readonly ApplicationUserManager userManager;

        public UsersController()
        {
            userManager = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var users = userManager
                .Users
                .ToList()
                .Select(user => new UserViewModel(user));

            return View(users);
        }
    }
}