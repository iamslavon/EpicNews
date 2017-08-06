using System.Web.Mvc;

namespace EbaNews.Web.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                name: "",
                url: "mngmnt",
                defaults: new { area = "Admin", controller = "Home", action = "Index" }
            );

            RegisterAccountRoutes(context);
            RegisterUserRoutes(context);
            RegisterNewsRoutes(context);
        }

        public void RegisterAccountRoutes(AreaRegistrationContext context)
        {
            context.MapRoute(
                name: "",
                url: "mngmnt/login",
                defaults: new { area = "Admin", controller = "Home", action = "Login" }
            );

            context.MapRoute(
                name: "",
                url: "mngmnt/logout",
                defaults: new { area = "Admin", controller = "Home", action = "Logout" }
            );

            context.MapRoute(
                name: "",
                url: "mngmnt/signup",
                defaults: new { area = "Admin", controller = "Home", action = "SignUp" }
            );

            context.MapRoute(
                name: "",
                url: "mngmnt/password/change",
                defaults: new { area = "Admin", controller = "Home", action = "ChangePassword" }
            );
        }

        public void RegisterUserRoutes(AreaRegistrationContext context)
        {
            context.MapRoute(
                name: "",
                url: "mngmnt/users",
                defaults: new { area = "Admin", controller = "Users", action = "Index" }
            );

            context.MapRoute(
                name: "",
                url: "mngmnt/users/get",
                defaults: new { area = "Admin", controller = "Users", action = "GetUsers" }
            );

            context.MapRoute(
                name: "",
                url: "mngmnt/users/role/switch",
                defaults: new { area = "Admin", controller = "Users", action = "SwitchRole" }
            );
        }

        public void RegisterNewsRoutes(AreaRegistrationContext context)
        {
            context.MapRoute(
                name: "",
                url: "mngmnt/news",
                defaults: new { area = "Admin", controller = "News", action = "Index" }
            );

            context.MapRoute(
                name: "",
                url: "mngmnt/news/get",
                defaults: new { area = "Admin", controller = "News", action = "GetNews" }
            );

            context.MapRoute(
                name: "",
                url: "mngmnt/news/online/switch",
                defaults: new { area = "Admin", controller = "News", action = "SwitchOnlineStatus" }
            );
        }
    }
}