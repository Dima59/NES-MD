using System;
using System.Linq;
using System.Web.Mvc;
using NES.Models;

namespace NES.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        // Verify User
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Authorise(UserLoginView model)
        {
            using (LoginEntities db = new LoginEntities())
            {
                try
                {
                    var userNameCredentals = db.UserLoginView.Where(x => x.UserName == model.UserName).FirstOrDefault();
                    var userPasswordCredentals = db.UserLoginView.Where(x => x.UserName == model.UserName && x.Password == model.Password).FirstOrDefault();
                    var userIsActivatedCredentals = db.UserLoginView.Where(x => x.UserName == model.UserName && x.IsActivated == model.IsActivated).FirstOrDefault();

                    if (userNameCredentals == null || userPasswordCredentals == null || userIsActivatedCredentals == null)
                    {
                        if (userNameCredentals == null)
                        {
                            ModelState.AddModelError("userName", "Invalid User Name!");
                        }
                        if (userPasswordCredentals == null && userNameCredentals != null)
                        {
                            ModelState.AddModelError("Password", "Invalid Password!");
                        }
                        if (userIsActivatedCredentals == null && userNameCredentals != null)
                        {
                            ModelState.AddModelError("userName", "User is not activated!");
                        }

                        return View("Index", model);
                    }

                    Session["userID"] = model.UserID;
                    Session["userName"] = model.UserName;
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception)
                {
                    model.LoginErrorMsg = "Can't verify user! Network or server error?";
                    return View("Index", model);
                }
            }
        }

        // Logout User
        [HttpGet]
        public ActionResult LogOut()
        {
            //int userID = (int)Session["userID"];
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}