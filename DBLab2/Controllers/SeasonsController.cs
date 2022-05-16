using DBLab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;

namespace DBLab2.Controllers
{
    public class SeasonsController : Controller
    {
        private ApplicationDbContext _context;
        public SeasonsController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var menus = _context.Seasons.ToList();
            return View(menus);
        }
        public ActionResult Create()
        {
            var season = new Season();
            return View("Form", season);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save( Season season)
        {
            if (!ModelState.IsValid)
            {
                return View("Form", season);
            }
            if (season.Id == 0)
                _context.Seasons.Add(season);
            else
            {
                var seasonInDb = _context.Seasons.Single(s => s.Id == season.Id);
                seasonInDb.Name = season.Name;
                seasonInDb.Description = season.Description;
                seasonInDb.StartDate = season.StartDate;
                seasonInDb.EndDate = season.EndDate;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Seasons");
        }
        public ActionResult Edit(int id)
        {
            var season = _context.Seasons.SingleOrDefault(s => s.Id == id);
            if (season == null)
                return HttpNotFound();
            return View("Form", season);
        }
        public ActionResult Delete(int id)
        {
            var season = _context.Seasons.Single(s => s.Id == id);
            _context.Seasons.Remove(season);
            _context.SaveChanges();
            return RedirectToAction("Index", "Seasons");
        }

    }
}