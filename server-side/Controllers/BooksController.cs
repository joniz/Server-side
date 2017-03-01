using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using service.Models;
using PagedList;
using PagedList.Mvc;

namespace server_side.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        public ActionResult books(string search, int? page)
        {
            return View(Books.getBookList(search).ToPagedList(page ?? 1, 11));
        }
        public ActionResult bookDetails(string isbn)
        {
            ViewBag.ISBN = isbn;
            return View(Books.getBook(isbn));


        } 


    }
}