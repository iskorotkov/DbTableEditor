using System.Collections.Generic;

namespace DbTableEditor.Data.Model
{
    public partial class GovernmentType
    {
        public GovernmentType()
        {
            Empires = new HashSet<Empire>();
        }

        public virtual ICollection<Empire> Empires { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
