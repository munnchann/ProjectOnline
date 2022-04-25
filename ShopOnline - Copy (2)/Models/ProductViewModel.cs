using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopOnline.Models
{
    public class ProductViewModel
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public int Amount { get; set; }
        public string CateProduct { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public string Detail { get; set; }
        public Nullable<System.DateTime> Warranty { get; set; }

        public List<string> Categories { get; set; } = new List<string>();
    }
}