using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using service.Models;
using PagedList;
using PagedList.Mvc;
using service.Security;
using System.ComponentModel.DataAnnotations;

namespace server_side.Controllers
{
    public class AuthorsController : Controller
    {
        // GET: Authors
        public ActionResult authors(int? page)
        {
            if (Account.testConn())
            {
                return View(Author.getAuthorList().ToPagedList(page ?? 1, 15));
            }
            List<Author> _emptyList = new List<Author>();
            ViewBag.serverError = "No connection to database";
            return View("authors", _emptyList.ToPagedList(page ?? 1, 15));

            
        }
        public ActionResult authorSearch(string search, int? page)
        {
            List<Author> _authorList = new List<Author>();
            if (Account.testConn())
            {
                if (search != null)
                {
                    foreach (var author in Author.getAuthorList())
                    {
                        if (author.FirstName != null && author.LastName != null)
                        {
                            if (author.FirstName.Contains(search) || author.LastName.Contains(search))
                            {
                                _authorList.Add(author);
                            }
                        }
                    }
                    if (_authorList.Count == 0)
                    {
                        ViewBag.error = "No match was found";
                        return View("authors", _authorList.ToPagedList(page ?? 1, 15));
                    }
                    else
                    {
                        return View("authors", _authorList.ToPagedList(page ?? 1, 15));
                    }


                }
                return View("authors", Author.getAuthorList().ToPagedList(page ?? 1, 15));
            }
            ViewBag.serverError = "No connection to database";
            return View("authors");
        }

            
        public ActionResult authorDetails(int authorId)
        {
            if (Account.testConn())
            {
                return View(Author.getAuthor(authorId));
            }
            ViewBag.serverError = "No connection to database";
            return View("authors");
        }
        public bool checkInput(string firstName, string lastName, int birthYear)
        {

        }
        [CustomAuthorizeAttribut(Roles = "megaAdmin, admin")]
        [HttpGet]
        public ActionResult editAuthor(int aID)
        {
            viewModel _viewModel = new viewModel();
            if (Account.testConn())
            {
                
                _viewModel.authorList = Author.getAuthorList();
                _viewModel.author = Author.getAuthor(aID);

                return View("editAuthor", _viewModel);
            }

            ViewBag.serverError = "No connection to database";
            return View("authors", _viewModel);
        }

        [CustomAuthorizeAttribut(Roles = "megaAdmin, admin")]
        [HttpPost]
        public ActionResult editAuthor(string firstName, string lastName, int birthYear, int aID)
        {
            Author _authObj = new Author();
            _authObj.FirstName = firstName;
            _authObj.LastName = lastName;
            _authObj.BirthYear = birthYear;
            _authObj.Aid = aID;
            /////
            if (checkInput(_authObj))
            {
                Author.editAuthor(_authObj);
                return View("authors", Author.getAuthorList().ToPagedList(1, 15));
            }
            else
            {
                viewModel vmodel = new viewModel();
                vmodel.author = _authObj;

                if (ModelState.IsValid)
                {
                    ViewBag.ErrorDan = "Incorrect input";
                }
                else
                {
                    ViewBag.ErrorWar = "Not a valid input";
                }
                return View("editAuthor", vmodel);

            }
        }
        public ActionResult editAuthor(string firstName, string lastName, int? birthYear, int? aID)
        {
            if (Account.testConn())
            {
                viewModel _viewModel = new viewModel();
                Author _authObj = new Author();
                _authObj.FirstName = firstName;
                _authObj.LastName = lastName;
                _authObj.BirthYear = (int?)birthYear;
                _authObj.Aid = (int?)aID;

                if (ModelState.IsValid) //Validator.TryValidateObject(_authObj, context, result, true))
                {

                    Author.editAuthor(_authObj);
                }
                else
                {
                    return View("editAuthor", _viewModel);
                }

                return View("authors", Author.getAuthorList().ToPagedList(1, 15));
            }
            ViewBag.serverError = "No connection to database";
            return View("authors");

        }
        [CustomAuthorizeAttribut(Roles = "megaAdmin")]
        public ActionResult showCreateAuthor()
        {
            if (Account.testConn())
            {
                return View("createAuthor");
            }
            ViewBag.serverError = "No connection to database";
            return View("authors");
        }
        [CustomAuthorizeAttribut(Roles = "megaAdmin")]
        public ActionResult createAuthor(int birthYear, string firstName, string lastName)
        {
            if (Account.testConn())
            {
                Author _authotObj = new Author();
                _authotObj.BirthYear = birthYear;
                _authotObj.FirstName = firstName;
                _authotObj.LastName = lastName;

                if (ModelState.IsValid)
                {
                    Author.addAuthor(_authotObj);
                }
                return View("authors", Author.getAuthorList().ToPagedList(1, 15));
            }
            ViewBag.serverError = "No connection to database";
            return View("authors");
        }
    }
}