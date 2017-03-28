using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace server_side.Controllers
{
    public class AdministratorController : Controller
    {
        // GET: Administrator
        public ActionResult administrator()
        {
            return View("Administrator");
        }
        public ActionResult administratorDetails(int admId)
        {
            ViewBag.id = admId;
            return View("administratorDetails");
            

        }
    }
}