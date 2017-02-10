using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using service.Models;

namespace WebApplication1.Controllers
{
    public class BooksController : Controller
    {
        List<Books> _bookList = new List<Books>();
        
        
        // GET: Books
        public ActionResult books()
        {
            return View("books");
        }
    }
}