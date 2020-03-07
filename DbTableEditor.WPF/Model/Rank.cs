﻿using System.Collections.Generic;

namespace DbTableEditor.WPF.Model
{
    public partial class Rank
    {
        public Rank()
        {
            Commanders = new HashSet<Commander>();
        }

        public virtual ICollection<Commander> Commanders { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
