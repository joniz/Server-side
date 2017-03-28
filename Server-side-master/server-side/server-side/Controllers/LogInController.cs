using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace server_side.Controllers
{
    public class LogInController : Controller
    {
        // GET: LogIn
        public ActionResult logIn()
        {
            return View("logIn");
        }
    }
}