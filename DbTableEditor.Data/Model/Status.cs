﻿using System.Collections.Generic;

namespace DbTableEditor.Data.Model
{
    public partial class Statuses
    {
        public Statuses()
        {
            Fleets = new HashSet<Fleet>();
        }

        public virtual ICollection<Fleet> Fleets { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
