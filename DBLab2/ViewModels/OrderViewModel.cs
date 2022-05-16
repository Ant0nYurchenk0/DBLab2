using DBLab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBLab2.ViewModels
{
    public class OrderViewModel
    {
        public Order Order{ get; set; }
        public List<Dish> Dishes { get; set; }
        public List<int> DishIds { get; set; }
    }
}