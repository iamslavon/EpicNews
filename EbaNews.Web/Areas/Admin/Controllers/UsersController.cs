using EbaNews.Core;
using EbaNews.Services.Membership;
using EbaNews.Web.Areas.Admin.Models.Users;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EbaNews.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = Roles.Owner)]
    public class UsersController : BaseController
    {
        private readonly ApplicationUserManager userManager;

        public UsersController()
        {
            userManager = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetUsers()
        {
            var users = userManager
                .Users
                .ToList()
                .Select(user => new UserViewModel
                {
                    Id = user.Id,
                    Name = user.UserName,
                    Email = user.Email,
                    Roles = userManager.GetRoles(user.Id)
                });

            return Json(users, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> SwitchRole(SwitchRoleViewModel model)
        {
            if (await userManager.IsInRoleAsync(model.UserId, model.Role))
            {
                await userManager.RemoveFromRoleAsync(model.UserId, model.Role);
            }
            else
            {
                await userManager.AddToRoleAsync(model.UserId, model.Role);
            }

            return Json(userManager.GetRoles(model.UserId));
        }
    }
}