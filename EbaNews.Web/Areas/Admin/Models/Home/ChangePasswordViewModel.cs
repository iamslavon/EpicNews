using System.ComponentModel.DataAnnotations;
using strings = EbaNews.Resources.Web.Areas.Admin.Models.ChangePasswordStrings;

namespace EbaNews.Web.Areas.Admin.Models.Home
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessageResourceType = typeof(strings), ErrorMessageResourceName = "CurrentPasswordFieldRequired")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessageResourceType = typeof(strings), ErrorMessageResourceName = "NewPasswordFieldRequired")]
        public string NewPassword { get; set; }

        [Required(ErrorMessageResourceType = typeof(strings), ErrorMessageResourceName = "ConfirmPasswordFieldRequired")]
        [Compare("NewPassword", ErrorMessageResourceType = typeof(strings), ErrorMessageResourceName = "ConfirmPasswordFail")]
        public string ConfirmPassword { get; set; }
    }
}