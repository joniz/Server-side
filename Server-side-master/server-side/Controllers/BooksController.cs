using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using service.Models;
using PagedList;
using PagedList.Mvc;
using service.Security;
using System.Text.RegularExpressions;

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
        private bool checkInput(Books book)
        {
            if (book.Title == null || book.ISBN == null || book.SignId == 0 || book.PublicationYear == null || book.PublicationInfo == null || book.pages == 0 || book.pages < 0)
            {
                return false;
            }

            string number = @"([0-9])+";
            string text = @"([A-Za-zÅÄÖåäö0-9\.,!: ])+";

            Match tResult = Regex.Match(book.Title, text);
            Match iResult = Regex.Match(book.ISBN, number);
            Match sResult = Regex.Match(book.SignId.ToString(), number);
            Match yResult = Regex.Match(book.PublicationYear, number);
            Match pResult = Regex.Match(book.pages.ToString(), number);
            Match inResult = Regex.Match(book.PublicationInfo, text);

            if (tResult.Success && iResult.Success && sResult.Success && yResult.Success && pResult.Success && inResult.Success && (book.ISBN.Length > 6 && book.ISBN.Length < 16))
            {
                return true;
            }
            return false;
        }
        [CustomAuthorizeAttribut(Roles = "megaAdmin, admin")]
        [HttpGet]
        public ActionResult createBook()
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
        [HttpPost]
        public ActionResult createBook(string title, List<int> aID, string publicationYear, int? signId, string isbn, int? pages, string publicationInfo)
        {
            List<Author> authorList = new List<Author>();
            Books _bookObj = new Books();
            if (Account.testConn())
            {
                _bookObj.Title = title;
                _bookObj.PublicationYear = publicationYear;
                _bookObj.SignId = signId ?? default(int);
                _bookObj.CLASSIFICATION = Classification.getClassification(signId ?? default(int));
                _bookObj.ISBN = isbn;
                _bookObj.pages = pages ?? default(int);
                _bookObj.PublicationInfo = publicationInfo;

              
                foreach (int id in aID)
                {
                    authorList.Add(Author.getAuthor(id));
                }
                _bookObj.AUTHORs = authorList;
                   
                
            }
            if (checkInput(_bookObj))
            {
                if (ModelState.IsValid)
                {
                    Books.addBook(_bookObj);
                    return View("books", Books.getBookList().ToPagedList(1, 15));
                }

            }else
            {
                viewModel vmodel = new viewModel();
                vmodel.book = _bookObj;
                vmodel.authorList = Author.getAuthorList();
                vmodel.classificationList = Classification.getClassificationList();
                ViewBag.ErrorDan = "Input incorrect";
                return View("createBook", vmodel);
            }
              
            ViewBag.serverError = "No connection to database";
            return View("books", authorList.ToPagedList(1, 15));
        }
        [CustomAuthorizeAttribut(Roles = "megaAdmin, admin")]
        [HttpGet]
        public ActionResult editBook(string isbn)
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
        [HttpPost]
        public ActionResult editBook(string title, List<int> aID, string publicationYear, string publicationInfo, int? signId, int? pages, string ISBN)
        {
            List<Author> authorList = new List<Author>();
            Books _bookObj = new Books();
            if (Account.testConn()) {
                _bookObj.ISBN = ISBN;
                _bookObj.Title = title;
                foreach (int id in aID.ToList())
                {
                    authorList.Add(Author.getAuthor(id));
                }
                _bookObj.AUTHORs = authorList;
                _bookObj.PublicationYear = publicationYear;
                _bookObj.PublicationInfo = publicationInfo;
                _bookObj.SignId = signId ?? default(int);
                _bookObj.pages = pages ?? default(int);
                _bookObj.CLASSIFICATION = Classification.getClassification(signId ?? default(int));

            }
            ////////// 
            if (checkInput(_bookObj))
            {
                if (ModelState.IsValid)
                {
                    Books.editBook(_bookObj);
                    return View("books", Books.getBookList().ToPagedList(1, 15));
                }
            }
            else
            {
                viewModel vmodel = new viewModel();
                vmodel.book = _bookObj;
                vmodel.authorList = Author.getAuthorList();
                vmodel.classificationList = Classification.getClassificationList();
                ViewBag.ErrorDan = "Input incorrect";
                return View("editBook", vmodel);
            }

            ViewBag.serverError = "No connection to database";
            return View("books", authorList);
        }
    }
}