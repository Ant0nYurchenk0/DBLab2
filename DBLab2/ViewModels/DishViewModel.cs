using DBLab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBLab2.ViewModels
{
    public class DishViewModel
    {
        public List<Menu> Menus { get; set; }
        public Dish Dish { get; set; }
        public List<int> MenuIds { get; set; }
    }
}