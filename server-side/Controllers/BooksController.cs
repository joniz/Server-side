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
            return View(Books.getBookList(search).ToPagedList(page ?? 1, 15));
        }

        public ActionResult bookDetails(string isbn)
        {
            

                viewModel _viewModel = new viewModel();
                _viewModel.authorList = Books.getBookAuthor(isbn);
                _viewModel.book = Books.getBook(isbn);

                // _viewModel.book.
                return View(_viewModel);
            
            
        }
        public ActionResult createBook()
        {
            return View("createBook");
            
        } 


    }
}