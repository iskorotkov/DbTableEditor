using System;
using System.Collections.Generic;

namespace DbTableEditor.WPF
{
    public partial class Alliances
    {
        public Alliances()
        {
            AlliancesEntries = new HashSet<AlliancesEntries>();
        }

        public int Id { get; set; }
        public int Power { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AlliancesEntries> AlliancesEntries { get; set; }
    }
}
