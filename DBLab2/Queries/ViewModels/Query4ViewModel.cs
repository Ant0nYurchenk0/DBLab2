using DBLab2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DBLab2.Queries.ViewModels
{
    public class Query4ViewModel
    {
        [Required]
        [Display(Name = "Season Name")]
        public string SeasonName { get; set; }
        public List<Season> Seasons { get; set; }
    }
}