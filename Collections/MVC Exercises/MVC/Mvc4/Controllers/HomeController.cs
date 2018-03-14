using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc4.Models;

namespace Mvc4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";
            /// <summary>
            /// TODO:To get data and returning result to the index view..
            /// </summary>
            /// <returns></returns>
            return View(new PartialModel() { lstPartialModel = GetSampleData() });
        }
        public ActionResult About()
        {
            return View();
        }
        /// <summary>
        /// TODO:Function to add some data to list.
        /// </summary>
        /// <returns></returns>
        private List<PartialModel> GetSampleData()
        {
            List<PartialModel> model = new List<PartialModel>();
            model.Add(new PartialModel()
            {
                Name = "Aravind",
                Actual = 10000,
                Target = 12000,
                Score = 83
            });
            model.Add(new PartialModel()
            {

                Name = "Ram",
                Actual = 8000,
                Target = 14000,
                Score = 57
            });
            model.Add(new PartialModel()
            {
                Name = "Ajay",
                Actual = 50000,
                Target = 35000,
                Score = 143
            });
            return model;
        }
    }
}
