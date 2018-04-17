using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webcouch.Models
{
    public class AssetDetails
    {
        public int AssetDetailsID { get; set; }
        public int AssetId { get; set; }
        public int CheckoutId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public virtual Assets Asset { get; set; }
        public virtual Checkout Order { get; set; }

    }
}
