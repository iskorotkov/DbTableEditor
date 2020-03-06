using System;
using System.Collections.Generic;

namespace DbTableEditor.WPF
{
    public partial class GovernmentTypes
    {
        public GovernmentTypes()
        {
            Empires = new HashSet<Empires>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Empires> Empires { get; set; }
    }
}
