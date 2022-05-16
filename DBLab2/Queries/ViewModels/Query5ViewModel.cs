using DBLab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBLab2.Queries.ViewModels
{
    public class Query5ViewModel
    {
        public string IngredientName { get; set; }
        public List<Ingredient> Ingredients{ get; set; }
    }
}