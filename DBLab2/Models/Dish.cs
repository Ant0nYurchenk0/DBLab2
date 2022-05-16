using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DBLab2.Models
{
    public class Dish
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        public int Price { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<Ingredient> Ingredients { get; set; }

        public ICollection<Menu> Menus { get; set; }

    }
}