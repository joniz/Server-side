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
            if (Account.testConn())
            {
                if (Account.logInAccount(user))
                {
                    SessionPersister.Username = user.Username;
                    return View("loggedInScreen");
                }
                else
                {
                    ViewBag.error = "Username or Password is wrong";
                    return View("logIn");
                }
            }
            
             ViewBag.error = "No connection to database";
             return View("logIn");
            
            
            
            
            //Account am = new Account();
            //if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password) || am.logIn(user.Username, user.Password) == null)
            //{
            //    ViewBag.Error = "Account is invalid";
            //    return View("logIn");
            //}
           
        }
        public ActionResult logOut()
        {
            SessionPersister.Username = string.Empty;
            return RedirectToAction("viewLogin");
        }

    }
}