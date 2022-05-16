using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DBLab2.Models;
using DBLab2.ViewModels;

namespace DBLab2.Controllers
{
    public class IngredientsController : Controller
    {
        // GET: Ingredients
        private ApplicationDbContext _context;
        public IngredientsController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var ingredients = _context.Ingredients.Include(i => i.Dishes).ToList();
            return View(ingredients);
        }
        public ActionResult Create()
        {
            var viewModel = new IngredientViewModel();
            viewModel.Dishes = _context.Dishes.ToList();
            viewModel.Ingredient = new Ingredient();
            viewModel.Ingredient.Dishes = new List<Dish>();
            viewModel.DishIds = new List<int>();
            return View("Form", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Ingredient ingredient, List<int> DishIds)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new IngredientViewModel();
                viewModel.Dishes = _context.Dishes.ToList();
                viewModel.Ingredient = new Ingredient();
                return View("Form", viewModel);
            }
            if(DishIds == null)
                ingredient.Dishes = _context.Ingredients.Include(i=>i.Dishes).Single(d => d.Id == ingredient.Id).Dishes;
            else if ( DishIds.Count != 0)
                ingredient.Dishes = _context.Dishes.Where(d => DishIds.Contains(d.Id)).ToList();
            else
                ingredient.Dishes = new List<Dish>();
            if (ingredient.Id == 0)
                _context.Ingredients.Add(ingredient);
            else
            {
                var ingredientInDb = _context.Ingredients.Include(i=>i.Dishes).Single(i => i.Id == ingredient.Id);
                ingredientInDb.Name = ingredient.Name;
                ingredientInDb.Description = ingredient.Description;
                ingredientInDb.Dishes.Clear();
                ingredientInDb.Dishes = ingredient.Dishes;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Ingredients");
        }
        public ActionResult Edit(int id)
        {
            var ingredient = _context.Ingredients.Include(i => i.Dishes).SingleOrDefault(i =>i.Id == id);
            if (ingredient == null)
                return HttpNotFound();
            var viewModel = new IngredientViewModel();
            viewModel.Dishes = _context.Dishes.ToList();
            viewModel.DishIds = ingredient.Dishes.Select(m => m.Id).ToList();            
            viewModel.Ingredient = ingredient;

            return View("Form", viewModel);
        }
        public ActionResult Delete(int id)
        {
            var IngredientInDb = _context.Ingredients.Single(i => i.Id == id);
            _context.Ingredients.Remove(IngredientInDb);
            _context.SaveChanges();
            return RedirectToAction("Index", "Ingredients");
        }
    }
}