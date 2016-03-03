using System.Web.Mvc;

namespace IGS_Otomasyon.Areas.YBS
{
    public class YBSAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "YBS";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "YBS_default",
                "YBS/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}