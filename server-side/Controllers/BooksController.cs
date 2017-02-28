using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using service.Models;
namespace server_side.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        public ActionResult books()
        {
            return View("books");
        }
        public ActionResult bookDetails(string isbn)
        {
            ViewBag.ISBN = isbn;
            return View("bookDetails");


        } 


    }
}