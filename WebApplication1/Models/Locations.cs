using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public partial class Locations
    {
        public Locations()
        {
            Assets = new HashSet<Assets>();
            Checkout = new HashSet<Checkout>();
            Customers = new HashSet<Customers>();
        }

        public int AddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }

        public ICollection<Assets> Assets { get; set; }
        public ICollection<Checkout> Checkout { get; set; }
        public ICollection<Customers> Customers { get; set; }
    }
}
