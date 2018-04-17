using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace webcouch.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Checkout = new HashSet<Checkout>();
        }

        public int Customerid { get; set; }
        [DisplayName("First name")]
        [StringLength(100)]
        [Required]
        public string Firstname { get; set; }
        [DisplayName("Last name")]
        [StringLength(100)]
        [Required]
        public string Lastname { get; set; }
        [StringLength(10, ErrorMessage = "Only use numbers. Limited to 10 characters")]
        [DataType(DataType.PhoneNumber)]
        public string Cellphone { get; set; }
        [StringLength(10, ErrorMessage ="Only use numbers. Limited to 10 characters")]
        [DataType(DataType.PhoneNumber)]
        public string Officephone { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public int? Locationid { get; set; }

        public Locations Location { get; set; }
        public ICollection<Checkout> Checkout { get; set; }
    }
}
