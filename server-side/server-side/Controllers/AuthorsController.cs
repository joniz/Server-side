using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace server_side.Controllers
{
    public class AuthorsController : Controller
    {
        // GET: Authors
        public ActionResult authors()
        {

            return View("Authors");
        }
    }
}