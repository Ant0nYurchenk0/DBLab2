using DBLab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using DBLab2.ViewModels;

namespace DBLab2.Controllers
{
    public class DishesController : Controller
    {
        // GET: Dishes
        private ApplicationDbContext _context;
        public DishesController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var menus = _context.Dishes.Include(d => d.Menus).ToList();
            return View(menus);
        }
        public ActionResult Create()
        {
            var viewModel = new DishViewModel();
            viewModel.Menus = _context.Menus.ToList();
            viewModel.Dish = new Dish();
            viewModel.Dish.Menus = new List<Menu>();
            viewModel.MenuIds = new List<int>();
            return View("Form", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Dish dish, List<int> MenuIds)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new DishViewModel();
                viewModel.Menus = _context.Menus.ToList();
                viewModel.Dish = new Dish();
                return View("Form", viewModel);
            }
            if (MenuIds == null)
                dish.Menus = _context.Dishes.Include(d=>d.Menus).Single(d => d.Id == dish.Id).Menus;
            else if (MenuIds.Count != 0)
            {
                dish.Menus = _context.Menus.Where(m => MenuIds.Contains(m.Id)).ToList();
            }
            else
                dish.Menus = new List<Menu>();
            if (dish.Id == 0)
                _context.Dishes.Add(dish);
            else
            {
                var dishInDb = _context.Dishes.Include(d=>d.Menus).Single(d =>d.Id == dish.Id);
                dishInDb.Name = dish.Name;
                dishInDb.Description = dish.Description;
                dishInDb.Price = dish.Price;
                dishInDb.Menus.Clear();
                dishInDb.Menus = dish.Menus;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Dishes");
        }
        public ActionResult Edit(int id)
        {
            var dish = _context.Dishes.Include(m => m.Menus).SingleOrDefault(m => m.Id == id);
            if (dish == null)
                return HttpNotFound();
            var viewModel = new DishViewModel();
            viewModel.Dish = dish;
            viewModel.Menus = _context.Menus.ToList();
            viewModel.MenuIds = dish.Menus.Select(m=>m.Id).ToList();
            return View("Form", viewModel);
        }
        public ActionResult Delete(int id)
        {
            var dishInDb = _context.Dishes.Single(d => d.Id == id);
            _context.Dishes.Remove(dishInDb);
            _context.SaveChanges();
            return RedirectToAction("Index", "Dishes");
        }


    }
}