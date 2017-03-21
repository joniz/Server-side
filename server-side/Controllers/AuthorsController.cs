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
    public class AuthorsController : Controller
    {
        // GET: Authors
        public ActionResult authors(string search, int? page)
        {
            return View(Author.getAuthorList().ToPagedList(page ?? 1, 15));
        }
        public ActionResult authorDetails(int authorId)
        {
            viewModel _viewModel = new viewModel();
           
            //Author.getAuthor(authorId);
            
            return View(Author.getAuthor(authorId));


        }
    }
}