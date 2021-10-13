using System.Web.Mvc;

namespace NES.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult PageNotFound()
        {
            return View();
        }
    }
}