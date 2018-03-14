using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBEntries;

namespace Mvc4.Controllers
{
    public class AssertionTypesController : Controller
    {
        //
        // GET: /AssertionTypes/

        public ActionResult Index()
        {
            var db = new MyDbContext();
            if(db !=null)
            {
                var col = db.AssertionType;

                return View(viewName: "Assertions", model: col);
            }
            return View(viewName: "Error");
        }

    }
}
