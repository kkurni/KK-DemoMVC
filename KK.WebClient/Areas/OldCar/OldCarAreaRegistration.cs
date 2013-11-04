using System.Web.Mvc;

namespace KK.WebClient.Areas.oldCar
{
    public class OldCarAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "oldCar";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "oldCar_default",
                "oldCar/{controller}/{action}/{id}",
                new { controller= "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
