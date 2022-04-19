using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopOnline.Models
{
    public class CartModel
    {
        public Product product { get; set; }
        public int Quantity { get; set; }
        //List<CartModel> items = new List<CartModel>();
        public string TransportName { get; set; }
    }
}