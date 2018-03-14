using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBEntries;

namespace Mvc4.Controllers
{
    public class BooksController : Controller
    {
        //
        // GET: /Books/
        //private 
        public ActionResult Index()
        {
            var db = new MyDbContext();

            if (db != null)
            {
                var title = db.Books;

                return View(viewName: "Books", model: title);
            }


            return View(viewName: "Error");
        }

    }
}
