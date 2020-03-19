using System.Web.Mvc;

namespace CmdWebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return Content("CMD via HTTP");
        }
    }
}
