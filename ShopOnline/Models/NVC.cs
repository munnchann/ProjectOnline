using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopOnline.Models
{
    public class NVC
    {
        public string nvcid { get; set; }
        public string nvcname { get; set; }

        public static IEnumerable<NVC> GetNhaVanChuyen()
        {
            List<NVC> currentCart = new List<NVC>()
            {
            new NVC {
                nvcid = "B",nvcname = "Best Express"
            },
            new NVC {
              nvcid = "G",  nvcname = "GHN"
            },
            new NVC {
             nvcid = "K",   nvcname = "GHTK"
            },
            new NVC {
              nvcid = "V",  nvcname = "Vietnam Post"
            }
            };
            return currentCart;
        }
    }
}