using DBLab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBLab2.Queries.ViewModels
{
    public class Query8ViewModel
    {
        public int SeasonId { get; set; }
        public List<Season> Seasons{ get; set; }
    }
}