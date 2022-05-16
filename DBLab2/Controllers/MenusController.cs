using DBLab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using DBLab2.ViewModels;

namespace DBLab2.Controllers
{
    public class MenusController : Controller
    {
        private ApplicationDbContext _context;
        public MenusController()
        {
            _context = new ApplicationDbContext();  
        }
        public ActionResult Index()
        {
            var menus = _context.Menus.Include(m=>m.Season).ToList();
            return View(menus);
        }
        public ActionResult Create()
        {
            var viewModel = new MenuViewModel();
            viewModel.Seasons = _context.Seasons.ToList();
            viewModel.Menu = new Menu();
            return View("Form", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Menu menu)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MenuViewModel();
                viewModel.Menu = menu; 
                viewModel.Seasons = _context.Seasons.ToList();
                return View("Form", viewModel);
            }
            if (menu.Id == 0)
                _context.Menus.Add(menu);
            else
            {
                var menuInDb = _context.Menus.Single(m => m.Id == menu.Id);
                menuInDb.Name = menu.Name;
                menuInDb.Description = menu.Description;
                menuInDb.SeasonId = menu.SeasonId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Menus");
        }
        public ActionResult Edit(int id)
        {
            var menu = _context.Menus.Include(m => m.Season).SingleOrDefault(m => m.Id == id);
            if (menu == null)
                return HttpNotFound();
            var viewModel = new MenuViewModel();
            viewModel.Menu = menu;
            viewModel.Seasons = _context.Seasons.ToList();
            return View("Form", viewModel);
        }
        public ActionResult Delete(int id)
        {
            var menuInDb = _context.Menus.Single(m => m.Id == id);
            _context.Menus.Remove(menuInDb);
            _context.SaveChanges();
            return RedirectToAction("Index", "Menus");
        }


    }
}