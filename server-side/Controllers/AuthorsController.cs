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
    public class AuthorsController : Controller
    {
        // GET: Authors
        public ActionResult authors(int? page)
        {
            return View(Author.getAuthorList().ToPagedList(page ?? 1, 15));
        }
        public ActionResult authorSearch(string search, int? page)
        {
            List<Author> _authorList = new List<Author>();
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
                if(_authorList.Count == 0)
                {

                }else
                {
                    return View("authors", _authorList.ToPagedList(page ?? 1, 15));
                }

                
            }
            return View("authors", Author.getAuthorList().ToPagedList(page ?? 1, 15));
        }

            
        public ActionResult authorDetails(int authorId)
        {
            return View(Author.getAuthor(authorId));
        }
        [CustomAuthorizeAttribut(Roles = "megaAdmin, admin")]
        public ActionResult showEditAuthor(int aID)
        {
            viewModel _viewModel = new viewModel();
            _viewModel.authorList = Author.getAuthorList();
            _viewModel.author = Author.getAuthor(aID);

            return View("editAuthor", _viewModel);

        }
        [CustomAuthorizeAttribut(Roles = "megaAdmin, admin")]
        public ActionResult editAuthor(string firstName, string lastName, int birthYear, int aID)
        {
            Author _authObj = new Author();
            _authObj.FirstName = firstName;
            _authObj.LastName = lastName;
            _authObj.BirthYear = birthYear;
            _authObj.Aid = aID;
            if (ModelState.IsValid)
            {
                Author.editAuthor(_authObj);
            }

            return View("authors", Author.getAuthorList().ToPagedList(1, 15));


        }
        [CustomAuthorizeAttribut(Roles = "megaAdmin, admin")]
        public ActionResult showCreateAuthor()
        {
            
            return View("createAuthor");
        }
        [CustomAuthorizeAttribut(Roles = "megaAdmin")]
        public ActionResult createAuthor(int birthYear, string firstName, string lastName)
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
    }
}