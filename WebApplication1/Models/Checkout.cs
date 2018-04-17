using System;
using System.Collections.Generic;

namespace webcouch.Models
{
    public partial class Checkout
    {
        public int Checkoutid { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public int? Contactid { get; set; }
        public int? Locationid { get; set; }
        public int? Assetid { get; set; }

        public Assets Asset { get; set; }
        public Customers Contact { get; set; }
        public Locations Location { get; set; }
        public System.DateTime OrderDate { get; set; }
        public List<AssetDetails> AssetDetail { get; set; }
        public decimal Total { get; set; }
    }
}
