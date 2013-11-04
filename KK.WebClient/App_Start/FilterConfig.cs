using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using KK.WebClient.Filters;

namespace KK.WebClient
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //this for Web API Filter and general exception
            GlobalConfiguration.Configuration.Filters.Add(new GlobalExceptionFilterAttribute());
        }
    }
}