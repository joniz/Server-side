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
        public ActionResult showCreateBook()
        {
            viewModel _viewModel = new viewModel();
            _viewModel.authorList = Author.getAuthorList();
            _viewModel.classificationList = Classification.getClassificationList();
            return View("createBook",_viewModel);
            
        }
        public ActionResult createBook(string title, List<int> aID, string publicationYear, int signId, string isbn, int pages, string publicationInfo)
        {
            Books _bookObj = new Books();
            _bookObj._title = title;
            _bookObj._publicationYear = publicationYear;
            _bookObj._signId = signId;
            _bookObj.CLASSIFICATION = Classification.getClassification(signId);
            _bookObj._ISBN = isbn;
            _bookObj._pages = pages;
            _bookObj._publicationInfo = publicationInfo;

            List<Author> authorList = new List<Author>();
            foreach (int id in aID)
            {
                authorList.Add(Author.getAuthor(id));
            }
            _bookObj.AUTHORS = authorList;

            if (ModelState.IsValid)
            {
                Books.addBook(_bookObj);
            }
            return View("books", Books.getBookList().ToPagedList(1, 15));
        }
        public ActionResult showEditView(string isbn)
        {
            viewModel _viewModel = new viewModel();
            _viewModel.book = Books.getBook(isbn);
            _viewModel.authorList = Author.getAuthorList();

            return View("editBook",_viewModel);
        }
        public ActionResult editBook(string ISBN)
        {
            return View();
        }
    }
}