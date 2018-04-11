using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public partial class Colors
    {
        public Colors()
        {
            Assets = new HashSet<Assets>();
        }

        public int Colorid { get; set; }
        public string Color { get; set; }

        public ICollection<Assets> Assets { get; set; }
    }
}
