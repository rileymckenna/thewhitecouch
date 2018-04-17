using System;
using System.Collections.Generic;

namespace webcouch.Models
{
    public partial class Assets
    {
        public Assets()
        {
            Checkout = new HashSet<Checkout>();
            InverseRelated = new HashSet<Assets>();
        }

        public int Assetid { get; set; }
        public DateTime? AquiredDate { get; set; }
        public int? Imageid { get; set; }
        public bool? Checkedout { get; set; }
        public string Comments { get; set; }
        public string Description { get; set; }
        public double? Height { get; set; }
        public double? Width { get; set; }
        public double? Length { get; set; }
        public double? Weight { get; set; }
        public double? Purchaseprice { get; set; }
        public int? Relatedid { get; set; }
        public int? Categoryid { get; set; }
        public int? Colorid { get; set; }
        public int? Locationid { get; set; }

        public Categories Category { get; set; }
        public Colors Color { get; set; }
        public Images Image { get; set; }
        public Locations Location { get; set; }
        public Assets Related { get; set; }
        public ICollection<Checkout> Checkout { get; set; }
        public ICollection<Assets> InverseRelated { get; set; }
    }
}
