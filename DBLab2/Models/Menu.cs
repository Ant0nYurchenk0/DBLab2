using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DBLab2.Models
{
    public class Menu
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]
        [MinLength(3)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        public Season Season { get; set; }

        [Display(Name = "Season")]
        public int SeasonId { get; set; }

        public ICollection<Dish> Dishes { get; set; }
    }
}