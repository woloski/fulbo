using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fulbo.Models;

namespace Fulbo.Controllers
{
    public class HomeController : Controller
    {
        private FulboContext context = new FulboContext();

        public ActionResult Index()
        {
            var matches = this.context.Matches.Include("Fixture").Where(m => m.Fixture.Number == 1).ToList();

            return View(matches);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
