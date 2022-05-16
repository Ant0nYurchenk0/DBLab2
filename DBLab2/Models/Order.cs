using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DBLab2.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime DateOrdered { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        public ICollection<Dish> Dishes { get; set; }
    }
}