using System.Collections.Generic;

namespace DbTableEditor.Data.Model
{
    public partial class Empire
    {
        public Empire()
        {
            AlliancesEntries = new HashSet<AlliancesEntry>();
            Planets = new HashSet<Planet>();
        }

        public virtual ICollection<AlliancesEntry> AlliancesEntries { get; set; }
        public virtual GovernmentType GovernmentType { get; set; }
        public int GovernmentTypeId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Planet> Planets { get; set; }
        public int Power { get; set; }
        public string Ruler { get; set; }
    }
}
