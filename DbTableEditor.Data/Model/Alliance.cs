using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DbTableEditor.Data.Model
{
    [DisplayColumn(nameof(Name))]
    public partial class Alliance
    {
        public Alliance()
        {
            AlliancesEntries = new HashSet<AlliancesEntry>();
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<AlliancesEntry> AlliancesEntries { get; set; }
        [Range(0, int.MaxValue)]
        public int Power { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
