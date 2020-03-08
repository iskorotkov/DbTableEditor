using System.Collections.Generic;

namespace DbTableEditor.Data.Model
{
    public partial class Alliance
    {
        public Alliance()
        {
            AlliancesEntries = new HashSet<AlliancesEntry>();
        }

        public virtual ICollection<AlliancesEntry> AlliancesEntries { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Power { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
