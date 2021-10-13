using System.Web.Mvc;

namespace NES.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}