using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webcouch.Models
{
    public class ShoppingCartViewModel
    {
        public int ShoppingCartViewModelID { get; set; }
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}
