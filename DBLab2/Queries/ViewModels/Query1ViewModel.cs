using DBLab2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DBLab2.Queries.ViewModels
{
    public class Query1ViewModel
    {
        [Required]
        [Display(Name ="Menu Name")]
        public string MenuName { get; set; }
        public List<Menu> Menus { get; set; }
    }
}