using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public partial class Categories
    {
        public Categories()
        {
            Assets = new HashSet<Assets>();
        }

        public int Categoryid { get; set; }
        public string Category { get; set; }

        public ICollection<Assets> Assets { get; set; }
    }
}
