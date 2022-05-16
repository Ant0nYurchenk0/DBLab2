using DBLab2.Models;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Web.Mvc;
using DBLab2.ViewModels;

namespace DBLab2.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        private ApplicationDbContext _context;
        public OrdersController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var orders = _context.Orders.Include(o=>o.Dishes).ToList();
            return View(orders);
        }
        public ActionResult Create()
        {
            var viewModel = new OrderViewModel();
            viewModel.Dishes = _context.Dishes.ToList();
            viewModel.Order = new Order();
            viewModel.Order.Dishes = new List<Dish>();
            viewModel.DishIds = new List<int>();
            return View("Form", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Order order, List<int> DishIds)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new OrderViewModel();
                viewModel.Dishes = _context.Dishes.ToList();
                viewModel.Order = new Order();
                return View("Form", viewModel);
            }
            if (DishIds == null)
                order.Dishes = _context.Orders.Include(o => o.Dishes).Single(o => o.Id == order.Id).Dishes;
            else if (DishIds.Count != 0)
            {
                order.Dishes = _context.Dishes.Where(o => DishIds.Contains(o.Id)).ToList();
            }
            else
                order.Dishes = new List<Dish>();
            if (order.Id == 0)
            {
                order.DateOrdered = DateTime.Now;
                _context.Orders.Add(order);
            }
            else
            {
                var orderInDb = _context.Orders.Include(o => o.Dishes).Single(o => o.Id == order.Id);
                orderInDb.DateOrdered = order.DateOrdered;
                orderInDb.Description = order.Description;
                orderInDb.Dishes.Clear();
                orderInDb.Dishes = order.Dishes;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Orders");
        }
        public ActionResult Edit(int id)
        {
            var order = _context.Orders.Include(o => o.Dishes).SingleOrDefault(o => o.Id == id);
            if (order == null)
                return HttpNotFound();
            var viewModel = new OrderViewModel();
            viewModel.Order = order;
            viewModel.Dishes = _context.Dishes.ToList();
            viewModel.DishIds = order.Dishes.Select(o => o.Id).ToList();
            return View("Form", viewModel);
        }
        public ActionResult Delete(int id)
        {
            var orderInDb = _context.Orders.Include(o => o.Dishes).Single(o => o.Id == id);
            orderInDb.Dishes.Clear();
            _context.Orders.Remove(orderInDb);
            _context.SaveChanges();
            return RedirectToAction("Index", "Orders");
        }
    }
}