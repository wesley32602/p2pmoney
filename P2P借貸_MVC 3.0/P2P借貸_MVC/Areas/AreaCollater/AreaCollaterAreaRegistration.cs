using System.Web.Mvc;

namespace P2P借貸_MVC.Areas.AreaCollater
{
    public class AreaCollaterAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AreaCollater";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AreaCollater_default",
                "AreaCollater/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}