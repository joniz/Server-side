using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using service.Models;

namespace server_side.Controllers
{
    public class AdministratorController : Controller
    {
        // GET: Administrator
        public ActionResult administrator()
        {
            return View("Administrator", Account.getAccountList());
        }
        public ActionResult administratorDetails(string userName)
        {
            
            return View("administratorDetails", Account.getAccount(userName));
            

        }
        public ActionResult showEditView(string userName)
        {

            return View("editAdministrator", Account.getAccount(userName));

        }
        public ActionResult editAdministrator(string Password, string Username, string repeatedPassWord)
        {
            if (Password.Equals(repeatedPassWord))
            {
                Account _accObj = new Account();
                _accObj.Username = Username;
                _accObj.Password = Password;
                Account.editAccount(_accObj);
                return View("administrator", Account.getAccountList());
            }
            else
            {
                ViewBag.error = "Passwords did not match";
                return View("editAdministrator", Account.getAccount(Username));
            }
        }
    }
}