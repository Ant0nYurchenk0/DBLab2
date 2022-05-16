using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DBLab2.Models
{
    public class Season
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]
        [MinLength(3)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        [Required]
        [Display(Name ="Start Date")]
        public DateTime StartDate { get; set; }
        [Required]
        [Display(Name ="End Date")]
        public DateTime EndDate { get; set; }

        public ICollection<Menu> Menus { get; set; }
    }
}