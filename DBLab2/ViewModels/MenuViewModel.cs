using DBLab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBLab2.ViewModels
{
    public class MenuViewModel
    {
        public Menu Menu { get; set; }
        public List<Season> Seasons { get; set; }
    }
}