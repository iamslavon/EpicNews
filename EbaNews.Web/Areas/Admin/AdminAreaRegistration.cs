using System.Web.Mvc;

namespace EbaNews.Web.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName => "Admin";

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                name: "",
                url: "mngmnt",
                defaults: new { area = AreaName, controller = "Home", action = "Index" }
            );

            RegisterAccountRoutes(context);
            RegisterUserRoutes(context);
            RegisterNewsRoutes(context);
            RegisterLanguageRoutes(context);
            RegisterSuggestedNewsRoutes(context);
        }

        public void RegisterAccountRoutes(AreaRegistrationContext context)
        {
            context.MapRoute(
                name: "",
                url: "mngmnt/login",
                defaults: new { area = AreaName, controller = "Home", action = "Login" }
            );

            context.MapRoute(
                name: "",
                url: "mngmnt/logout",
                defaults: new { area = AreaName, controller = "Home", action = "Logout" }
            );

            context.MapRoute(
                name: "",
                url: "mngmnt/signup",
                defaults: new { area = AreaName, controller = "Home", action = "SignUp" }
            );

            context.MapRoute(
                name: "",
                url: "mngmnt/password/change",
                defaults: new { area = AreaName, controller = "Home", action = "ChangePassword" }
            );
        }

        public void RegisterUserRoutes(AreaRegistrationContext context)
        {
            context.MapRoute(
                name: "",
                url: "mngmnt/users",
                defaults: new { area = AreaName, controller = "Users", action = "Index" }
            );

            context.MapRoute(
                name: "",
                url: "mngmnt/users/get",
                defaults: new { area = AreaName, controller = "Users", action = "GetUsers" }
            );

            context.MapRoute(
                name: "",
                url: "mngmnt/users/role/switch",
                defaults: new { area = AreaName, controller = "Users", action = "SwitchRole" }
            );
        }

        public void RegisterNewsRoutes(AreaRegistrationContext context)
        {
            context.MapRoute(
                name: "",
                url: "mngmnt/news",
                defaults: new { area = AreaName, controller = "News", action = "Index" }
            );

            context.MapRoute(
                name: "",
                url: "mngmnt/news/get",
                defaults: new { area = AreaName, controller = "News", action = "GetNews" }
            );

            context.MapRoute(
                name: "",
                url: "mngmnt/news/add",
                defaults: new { area = AreaName, controller = "News", action = "AddNews" }
            );

            context.MapRoute(
                name: "",
                url: "mngmnt/news/edit",
                defaults: new { area = AreaName, controller = "News", action = "EditNews" }
            );

            context.MapRoute(
                name: "",
                url: "mngmnt/news/delete",
                defaults: new { area = AreaName, controller = "News", action = "DeleteNews" }
            );

            context.MapRoute(
                name: "",
                url: "mngmnt/news/online/switch",
                defaults: new { area = AreaName, controller = "News", action = "SwitchOnlineStatus" }
            );
        }

        public void RegisterLanguageRoutes(AreaRegistrationContext context)
        {
            context.MapRoute(
                name: "",
                url: "mngmnt/languages/get",
                defaults: new { area = AreaName, controller = "Language", action = "GetLanguages" }
            );
        }

        public void RegisterSuggestedNewsRoutes(AreaRegistrationContext context)
        {
            context.MapRoute(
                name: "",
                url: "mngmnt/news/suggested",
                defaults: new { area = AreaName, controller = "SuggestedNews", action = "Index" }
            );

            context.MapRoute(
                name: "",
                url: "mngmnt/news/suggested/get",
                defaults: new { area = AreaName, controller = "SuggestedNews", action = "GetNews" }
            );

            context.MapRoute(
                name: "",
                url: "mngmnt/news/suggested/decline",
                defaults: new { area = AreaName, controller = "SuggestedNews", action = "DeclineNews" }
            );

            context.MapRoute(
                name: "",
                url: "mngmnt/news/suggested/approve",
                defaults: new { area = AreaName, controller = "SuggestedNews", action = "ApproveNews" }
            );
        }
    }
}