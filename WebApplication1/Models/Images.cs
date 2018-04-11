using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public partial class Images
    {
        public Images()
        {
            Assets = new HashSet<Assets>();
        }

        public int Imageid { get; set; }
        public string Caption { get; set; }
        public byte[] Image { get; set; }

        public ICollection<Assets> Assets { get; set; }
    }
}
