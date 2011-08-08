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
    public class MatchesController : Controller
    {
        private FulboContext context = new FulboContext();

        //
        // GET: /Matches/

        public ViewResult Index()
        {
            return View(context.Matches.Include(match => match.HomeTeam).Include(match => match.AwayTeam).Include(match => match.Fixture).ToList());
        }

        //
        // GET: /Matches/Details/5

        public ViewResult Details(int id)
        {
            Match match = context.Matches.Single(x => x.Id == id);
            return View(match);
        }

        //
        // GET: /Matches/Create

        public ActionResult Create()
        {
            ViewBag.PossibleHomeTeams = context.Teams;
            ViewBag.PossibleAwayTeams = context.Teams;
            ViewBag.PossibleFixtures = context.Fixtures;
            return View();
        } 

        //
        // POST: /Matches/Create

        [HttpPost]
        public ActionResult Create(Match match)
        {
            if (ModelState.IsValid)
            {
                context.Matches.Add(match);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.PossibleHomeTeams = context.Teams;
            ViewBag.PossibleAwayTeams = context.Teams;
            ViewBag.PossibleFixtures = context.Fixtures;
            return View(match);
        }
        
        //
        // GET: /Matches/Edit/5
 
        public ActionResult Edit(int id)
        {
            Match match = context.Matches.Single(x => x.Id == id);
            ViewBag.PossibleHomeTeams = context.Teams;
            ViewBag.PossibleAwayTeams = context.Teams;
            ViewBag.PossibleFixtures = context.Fixtures;
            return View(match);
        }

        //
        // POST: /Matches/Edit/5

        [HttpPost]
        public ActionResult Edit(Match match)
        {
            if (ModelState.IsValid)
            {
                context.Entry(match).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PossibleHomeTeams = context.Teams;
            ViewBag.PossibleAwayTeams = context.Teams;
            ViewBag.PossibleFixtures = context.Fixtures;
            return View(match);
        }

        //
        // GET: /Matches/Delete/5
 
        public ActionResult Delete(int id)
        {
            Match match = context.Matches.Single(x => x.Id == id);
            return View(match);
        }

        //
        // POST: /Matches/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Match match = context.Matches.Single(x => x.Id == id);
            context.Matches.Remove(match);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}