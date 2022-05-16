using DBLab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBLab2.Queries.ViewModels
{
    public class Query7ViewModel
    {
        public int OrderId { get; set; }
        public List<Order> Orders { get; set; }
    }
}