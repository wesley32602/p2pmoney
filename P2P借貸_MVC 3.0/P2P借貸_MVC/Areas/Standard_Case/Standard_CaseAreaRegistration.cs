using System.Web.Mvc;

namespace P2P借貸_MVC.Areas.Standard_Case
{
    public class Standard_CaseAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Standard_Case";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Standard_Case_default",
                "Standard_Case/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}