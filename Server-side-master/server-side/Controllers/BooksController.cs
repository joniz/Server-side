using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using service.Models;
using PagedList;
using PagedList.Mvc;
using service.Security;
namespace server_side.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        public ActionResult books(int? page)
        {
            viewModel _viewModel = new viewModel();
            
            if (Account.testConn())
            {
                
                _viewModel.bookList = Books.getBookList();
                return View(Books.getBookList().ToPagedList(page ?? 1, 15));
            }
            List<Books> _emptyList = new List<Books>();
            ViewBag.serverError = "No connection to database";
            return View("books", _emptyList.ToPagedList(page ?? 1, 15));
        }
        public ActionResult bookSearch(string search, int? page)
        {
            List<Books> _bookList = new List<Books>();
            if (Account.testConn())
            {
                if (search != null)
                {
                    foreach (var book in Books.getBookList())
                    {
                        if (book.Title.Contains(search) || book.ISBN.Contains(search))
                        {
                            _bookList.Add(book);
                        }


                    }
                    if (_bookList.Count == 0)
                    {
                        ViewBag.error = "No match was found";
                        return View("books", _bookList.ToPagedList(page ?? 1, 15));
                    }
                    else return View("books", _bookList.ToPagedList(page ?? 1, 15));
                }
                return View("books", Books.getBookList().ToPagedList(page ?? 1, 15));
            }
            ViewBag.serverError = "No connection to database";
            return View("books", _bookList.ToPagedList(page ?? 1, 15));
        }
            
        

        public ActionResult bookDetails(string isbn)
        {
                viewModel _viewModel = new viewModel();
            if (Account.testConn())
            {
                _viewModel.authorList = Books.getBookAuthor(isbn);
                _viewModel.book = Books.getBook(isbn);

                // _viewModel.book.
                return View(_viewModel);
            }
            ViewBag.serverError = "No connection to database";
            return View("books", _viewModel);

        }
        [CustomAuthorizeAttribut(Roles = "megaAdmin, admin")]
        public ActionResult showCreateBook()
        {

            viewModel _viewModel = new viewModel();
            if (Account.testConn())
            {
                _viewModel.authorList = Author.getAuthorList();
                _viewModel.classificationList = Classification.getClassificationList();
                return View("createBook", _viewModel);
            }
            ViewBag.serverError = "No connection to database";
            return View("createBook", _viewModel);
        }
        [CustomAuthorizeAttribut(Roles = "megaAdmin, admin")]
        public ActionResult createBook(string title, List<int> aID, string publicationYear, int signId, string isbn, int pages, string publicationInfo)
        {
            List<Author> authorList = new List<Author>();
            if (Account.testConn())
            {
                Books _bookObj = new Books();
                _bookObj.Title = title;
                _bookObj.PublicationYear = publicationYear;
                _bookObj.SignId = signId;
                _bookObj.CLASSIFICATION = Classification.getClassification(signId);
                _bookObj.ISBN = isbn;
                _bookObj.pages = pages;
                _bookObj.PublicationInfo = publicationInfo;

               
                foreach (int id in aID)
                {
                    authorList.Add(Author.getAuthor(id));
                }
                _bookObj.AUTHORs = authorList;

                if (ModelState.IsValid)
                {
                    Books.addBook(_bookObj);
                }
                return View("books", Books.getBookList().ToPagedList(1, 15));
            }
            
            ViewBag.serverError = "No connection to database";
            return View("books", authorList.ToPagedList(1, 15));
        }
        [CustomAuthorizeAttribut(Roles = "megaAdmin, admin")]
        public ActionResult showEditView(string isbn)
        {
            viewModel _viewModel = new viewModel();
            if (Account.testConn())
            {
                _viewModel.book = Books.getBook(isbn);
                _viewModel.authorList = Author.getAuthorList();
                _viewModel.classificationList = Classification.getClassificationList();

                return View("editBook", _viewModel);
            }
            ViewBag.serverError = "No connection to database";
            return View("books", _viewModel);
        }
        [CustomAuthorizeAttribut(Roles = "megaAdmin, admin")]
        public ActionResult editBook(string title, List<int> aID, string publicationYear, string publicationInfo, int signId, int pages, string ISBN)
        {
            List<Author> authorList = new List<Author>();
            if(Account.testConn()) {
                Books _bookObj = new Books();
                _bookObj.ISBN = ISBN;
                _bookObj.Title = title;
                ;
                foreach (int id in aID.ToList())
                {
                    authorList.Add(Author.getAuthor(id));
                }
                _bookObj.AUTHORs = authorList;
                _bookObj.PublicationYear = publicationYear;
                _bookObj.PublicationInfo = publicationInfo;
                _bookObj.SignId = signId;
                _bookObj.pages = pages;
                _bookObj.CLASSIFICATION = Classification.getClassification(signId);
                if (ModelState.IsValid)
                {
                    Books.editBook(_bookObj);
                }

                return View("books", Books.getBookList().ToPagedList(1, 13));
            }
            ViewBag.serverError = "No connection to database";
            return View("books", authorList);
        }
    }
}