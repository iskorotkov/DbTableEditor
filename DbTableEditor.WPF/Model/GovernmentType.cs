using System.Collections.Generic;

namespace DbTableEditor.WPF.Model
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
    }
}
