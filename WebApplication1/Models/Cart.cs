using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webcouch.Models
{
    public class Cart
    {
        [Key]
        public int RecordID { get; set; }
        public string CartId { get; set; }
        public int AssetID { get; set; }
        public virtual Assets Assets { get; set; } 
        public System.DateTime DateCreated { get; set; }
        public int Count { get; set; }
    }
}
