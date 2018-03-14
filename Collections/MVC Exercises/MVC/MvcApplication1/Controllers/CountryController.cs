using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class CountryController : Controller
    {
        //
        // GET: /Country/

        public ActionResult Index()
        {
            //Country Countrires = new Country { CountryCode = 1, CountryName = "India" };
            List<Country> oCountries = new List<Country>(){
                new Country { CountryCode = 1, CountryName = "India" },
                new Country { CountryCode = 2, CountryName = "US" },
                new Country { CountryCode = 3, CountryName = "UK" }};

            //oCountries.Add(new Country { CountryCode = 1, CountryName = "India" });
            //oCountries.Add(new Country { CountryCode = 2, CountryName = "US" });
            //oCountries.Add(new Country { CountryCode = 3, CountryName = "UK" });
          
            return View(viewName:"Country", model:oCountries);
        }

    }
}
