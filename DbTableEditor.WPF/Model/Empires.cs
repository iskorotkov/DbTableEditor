using System;
using System.Collections.Generic;

namespace DbTableEditor.WPF
{
    public partial class Empires
    {
        public Empires()
        {
            AlliancesEntries = new HashSet<AlliancesEntries>();
            Planets = new HashSet<Planets>();
        }

        public int Id { get; set; }
        public int GovernmentTypeId { get; set; }
        public string Ruler { get; set; }
        public int Power { get; set; }
        public string Name { get; set; }

        public virtual GovernmentTypes GovernmentType { get; set; }
        public virtual ICollection<AlliancesEntries> AlliancesEntries { get; set; }
        public virtual ICollection<Planets> Planets { get; set; }
    }
}
