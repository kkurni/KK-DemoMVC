using System;
using System.Web.Mvc;

namespace KK.WebClient.Controllers
{
    /// <summary>
    /// This is SPA (Single Page App) controller
    /// </summary>    
    public class CarAppController : Controller
    {
        // GET: /carApp/Home/
        public ActionResult Index()
        {
            return View();
        }
    }
}
