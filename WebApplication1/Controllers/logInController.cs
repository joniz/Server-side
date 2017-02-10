using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class logInController : Controller
    {
        // GET: logIn
        public ActionResult logIn()
        {
            return View("logIn");
        }
    }
}