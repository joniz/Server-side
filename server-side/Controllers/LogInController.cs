using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using service.Models;
using service.Security;

namespace server_side.Controllers
{
    public class LogInController : Controller
    {
        public ActionResult viewLogIn()
        {
            return View("logIn");
        }
        // GET: LogIn
        [HttpPost]
        public ActionResult logIn(Account user)
        {
            AccountModel am = new AccountModel();
            if (string.IsNullOrEmpty(user.userName) || string.IsNullOrEmpty(user.passWord) || am.logIn(user.userName, user.passWord) == null)
            {
                ViewBag.Error = "Account is invalid";
                return View("logIn");
            }
            SessionPersister.userName = user.userName;
            return View("loggedInScreen");
        }
        public ActionResult logOut()
        {
            SessionPersister.userName = string.Empty;
            return RedirectToAction("viewLogin");
        }

    }
}