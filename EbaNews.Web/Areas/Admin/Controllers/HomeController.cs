using EbaNews.Core.Identity;
using EbaNews.Services.Membership;
using EbaNews.Web.Areas.Admin.Models.Home;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using strings = EbaNews.Resources.Default.Web.Areas.Admin.Controllers.HomeStrings;

namespace EbaNews.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        private readonly ApplicationUserManager userManager;
        private readonly IAuthenticationManager authenticationManager;


        public HomeController()
        {
            userManager = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            authenticationManager = System.Web.HttpContext.Current.GetOwinContext().Authentication;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            var model = new LoginViewModel();
            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = userManager.Find(model.Login, model.Password);

            if (user == null)
            {
                AddModelError(strings.WrongLoginOrPassword);
                return View(model);
            }

            if (!userManager.IsInRole(user.Id, "admin"))
            {
                AddModelError(strings.UserAccessDeny);
                return View(model);
            }

            var claim = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            authenticationManager.SignOut();
            var properties = new AuthenticationProperties
            {
                IsPersistent = model.KeepSigned
            };
            authenticationManager.SignIn(properties, claim);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Logout()
        {
            authenticationManager.SignOut();

            return RedirectToAction("Login", "Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult SignUp()
        {
            authenticationManager.SignOut();
            var model = new SignUpViewModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> SignUp(SignUpViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var passwordHash = new PasswordHasher().HashPassword(model.Password);
            var user = new ApplicationUser(model.Name, model.Email, passwordHash);
            var result = await userManager.CreateAsync(user);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user.Id, "user");
            }
            else
            {
                AddModelErrors(result.Errors);
                return View(model);
            }

            return RedirectToAction("Login", "Home");
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            var model = new ChangePasswordViewModel();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var id = User.Identity.GetUserId();
            var result = userManager.ChangePassword(id, model.CurrentPassword, model.NewPassword);

            if (result.Succeeded)
            {
                return RedirectToAction("Logout", "Home");
            }
            else
            {
                AddModelErrors(result.Errors);

                return View(model);
            }
        }
    }
}