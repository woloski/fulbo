using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fulbo.Models;

namespace Fulbo.Controllers
{   
    public class FixturesController : Controller
    {
        private FulboContext context = new FulboContext();

        //
        // GET: /Fixtures/

        public ViewResult Index()
        {
            return View(context.Fixtures.Include(fixture => fixture.Matches).ToList());
        }

        //
        // GET: /Fixtures/Details/5

        public ViewResult Details(int id)
        {
            Fixture fixture = context.Fixtures.Single(x => x.Id == id);
            return View(fixture);
        }

        //
        // GET: /Fixtures/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Fixtures/Create

        [HttpPost]
        public ActionResult Create(Fixture fixture)
        {
            if (ModelState.IsValid)
            {
                context.Fixtures.Add(fixture);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(fixture);
        }
        
        //
        // GET: /Fixtures/Edit/5
 
        public ActionResult Edit(int id)
        {
            Fixture fixture = context.Fixtures.Single(x => x.Id == id);
            return View(fixture);
        }

        //
        // POST: /Fixtures/Edit/5

        [HttpPost]
        public ActionResult Edit(Fixture fixture)
        {
            if (ModelState.IsValid)
            {
                context.Entry(fixture).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fixture);
        }

        //
        // GET: /Fixtures/Delete/5
 
        public ActionResult Delete(int id)
        {
            Fixture fixture = context.Fixtures.Single(x => x.Id == id);
            return View(fixture);
        }

        //
        // POST: /Fixtures/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Fixture fixture = context.Fixtures.Single(x => x.Id == id);
            context.Fixtures.Remove(fixture);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}