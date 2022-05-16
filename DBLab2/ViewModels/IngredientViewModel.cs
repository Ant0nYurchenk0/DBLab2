using DBLab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBLab2.ViewModels
{
    public class IngredientViewModel
    {
        public List<Dish> Dishes { get; set; }
        public Ingredient Ingredient { get; set; }
        public List<int> DishIds { get; set; }

    }
}