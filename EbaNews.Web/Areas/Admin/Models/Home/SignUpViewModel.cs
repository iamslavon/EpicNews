using System.ComponentModel.DataAnnotations;
using strings = EbaNews.Resources.Web.Areas.Admin.Models.SignUpStrings;

namespace EbaNews.Web.Areas.Admin.Models.Home
{
    public class SignUpViewModel
    {
        [Required(ErrorMessageResourceType = typeof(strings), ErrorMessageResourceName = "NameRequired")]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(strings), ErrorMessageResourceName = "EmailRequired")]
        [EmailAddress(ErrorMessageResourceType = typeof(strings), ErrorMessageResourceName = "WrongEmail")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(strings), ErrorMessageResourceName = "PasswordRequired")]
        public string Password { get; set; }

        [Required(ErrorMessageResourceType = typeof(strings), ErrorMessageResourceName = "ConfirmPasswordRequired")]
        [Compare("Password", ErrorMessageResourceType = typeof(strings), ErrorMessageResourceName = "ConfirmPasswordNotTheSame")]
        public string ConfirmPassword { get; set; }
    }
}