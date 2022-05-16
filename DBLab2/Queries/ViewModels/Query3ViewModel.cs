using DBLab2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DBLab2.Queries.ViewModels
{
    public class Query3ViewModel
    {
        [Required]
        [Display(Name = "Dish Name")]
        public string DishName { get; set; }
        public List<Dish> Dishes { get; set; }
    }
}