using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DbTableEditor.Data.Model
{
    [DisplayColumn(nameof(Name))]
    public partial class GovernmentType
    {
        public GovernmentType()
        {
            Empires = new HashSet<Empire>();
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Empire> Empires { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
