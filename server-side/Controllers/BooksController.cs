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
        public ActionResult books(int? page)
        {
            return View(Books.getBookList().ToPagedList(page ?? 1, 15));
                
        }
        public ActionResult bookSearch(string search, int? page)
        {
            List<Books> _bookList = new List<Books>();
            if (search != null)
            {
                foreach (var book in Books.getBookList())
                {
                    if (book._title.Contains(search) || book._ISBN.Contains(search))
                    {
                        _bookList.Add(book);
                    }
                }
                return View("books", _bookList.ToPagedList(page ?? 1, 15));
            }
            return View("books", Books.getBookList().ToPagedList(page ?? 1, 15));

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

            return View(Author.getAuthorList().ToList());
            
        }
        public ActionResult showEditView(string isbn)
        {
            return View("editBook",Books.getBook(isbn));
        }
        public ActionResult editBook(string ISBN)
        {
            return View();
        }
    }
}