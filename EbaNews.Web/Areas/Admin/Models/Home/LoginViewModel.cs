using System.ComponentModel.DataAnnotations;
using strings = EbaNews.Resources.Default.Web.Areas.Admin.Models.LoginViewModelStrings;

namespace EbaNews.Web.Areas.Admin.Models.Home
{
    public class LoginViewModel
    {
        [Required(ErrorMessageResourceType = typeof(strings), ErrorMessageResourceName = "LoginFieldRequired")]
        public string Login { get; set; }

        [Required(ErrorMessageResourceType = typeof(strings), ErrorMessageResourceName = "PasswordFieldRequired")]
        public string Password { get; set; }

        public bool KeepSigned { get; set; }
    }
}