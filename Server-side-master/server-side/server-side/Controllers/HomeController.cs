using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace server_side.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult home()
        {
            return View();
        }
    }
}