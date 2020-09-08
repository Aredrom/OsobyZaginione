using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OsobyZaginione.Models;

namespace OsobyZaginione.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorize(OsobyZaginione.Models.User user)
        {
            OsobyZagubioneDBEntities db = new OsobyZagubioneDBEntities();
            var userDetails = db.Users.Where(x => x.login == user.login && x.password == user.password).FirstOrDefault();
            if (userDetails == null)
            {
                 user.LoginErrorMessage = "Błędne hasło!";
                 return View("Login", user);
            }
            else
            {
                 Session["login"] = userDetails.login;
                 return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}