using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DbTableEditor.Data.Model
{
    [DisplayColumn(nameof(Name))]
    public partial class Empire
    {
        public Empire()
        {
            AlliancesEntries = new HashSet<AlliancesEntry>();
            Planets = new HashSet<Planet>();
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<AlliancesEntry> AlliancesEntries { get; set; }
        public virtual GovernmentType GovernmentType { get; set; }
        public int GovernmentTypeId { get; set; }
        public virtual ICollection<Planet> Planets { get; set; }
        public int Power { get; set; }
        public string Ruler { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
