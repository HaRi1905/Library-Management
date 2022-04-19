using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library_Management.Models;

namespace Library_Management.Controllers
{


    // GET: ViewBook
    public class ViewBookController : Controller
    {
        private LMSEntities db = new LMSEntities();

        // GET: ViewBook
        public ActionResult Index()
        {
            var books = db.Books;
            return View(books.ToList());
        }

        [HttpPost]
        public ActionResult Index(string BName, Book b)
        {

            var books = db.Books.ToList().Where(p => p.Book_Name.StartsWith(BName));
            return View(books);

        }

    }
 }
    