using DBLab2.Models;
using DBLab2.Queries.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBLab2.Queries
{
    public class QueryController : Controller
    {
        private ApplicationDbContext _context;

        public QueryController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Query1()
        {
            var viewModel = new Query1ViewModel();
            viewModel.MenuName = string.Empty;
            viewModel.Menus = _context.Menus.ToList();
            return View(viewModel);
        }
        public ActionResult Result1(string MenuName)
        {
            var queryStr = string.Format(QueryConstants.Query1Content, MenuName);
            var result = _context.Database.SqlQuery<Result1ViewModel>(queryStr).ToList();

            return View(result);
        }
        public ActionResult Query2()
        {
            var viewModel = new Query2ViewModel();
            viewModel.DishName = string.Empty;
            viewModel.Dishes = _context.Dishes.ToList();
            return View(viewModel);
        }
        public ActionResult Result2(string DishName)
        {
            var queryStr = string.Format(QueryConstants.Query2Content, DishName);
            var result = _context.Database.SqlQuery<Result2ViewModel>(queryStr).ToList();

            return View(result);
        }
        public ActionResult Query3()
        {
            var viewModel = new Query3ViewModel();
            viewModel.DishName = string.Empty;
            viewModel.Dishes = _context.Dishes.ToList();
            return View(viewModel);
        }
        public ActionResult Result3(string DishName)
        {
            var queryStr = string.Format(QueryConstants.Query3Content, DishName);
            var result = _context.Database.SqlQuery<Result3ViewModel>(queryStr).ToList();

            return View(result);
        }
        public ActionResult Query4()
        {
            var viewModel = new Query4ViewModel();
            viewModel.SeasonName = string.Empty;
            viewModel.Seasons = _context.Seasons.ToList();
            return View(viewModel);
        }
        public ActionResult Result4(string SeasonName)
        {
            var queryStr = string.Format(QueryConstants.Query4Content, SeasonName);
            var result = _context.Database.SqlQuery<Result4ViewModel>(queryStr).ToList();

            return View(result);
        }
        public ActionResult Query5()
        {
            var viewModel = new Query5ViewModel();
            viewModel.IngredientName = string.Empty;
            viewModel.Ingredients = _context.Ingredients.ToList();
            return View(viewModel);
        }
        public ActionResult Result5(string IngredientName)
        {
            var queryStr = string.Format(QueryConstants.Query5Content, IngredientName);
            var result = _context.Database.SqlQuery<Result5ViewModel>(queryStr).ToList();

            return View(result);
        }
        public ActionResult Query6()
        {
            var viewModel = new Query6ViewModel();
            viewModel.MenuId = 0;
            viewModel.Menus = _context.Menus.ToList();
            return View(viewModel);
        }
        public ActionResult Result6(int MenuId)
        {
            var queryStr = string.Format(QueryConstants.Query6Content, MenuId);
            var result = _context.Database.SqlQuery<Result6ViewModel>(queryStr).ToList();

            return View(result);
        }
        public ActionResult Query7()
        {
            var viewModel = new Query7ViewModel();
            viewModel.OrderId = 0;
            viewModel.Orders = _context.Orders.ToList();
            return View(viewModel);
        }
        public ActionResult Result7(int OrderId)
        {
            var queryStr = string.Format(QueryConstants.Query7Content, OrderId);
            var result = _context.Database.SqlQuery<Result7ViewModel>(queryStr).ToList();

            return View(result);
        }
        public ActionResult Query8()
        {
            var viewModel = new Query8ViewModel();
            viewModel.SeasonId = 0;
            viewModel.Seasons = _context.Seasons.ToList();
            return View(viewModel);
        }
        public ActionResult Result8(int SeasonId)
        {
            var queryStr = string.Format(QueryConstants.Query8Content, SeasonId);
            var result = _context.Database.SqlQuery<Result8ViewModel>(queryStr).ToList();

            return View(result);
        }
    }
}