using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DbTableEditor.Data.Model
{
    [DisplayColumn(nameof(Name))]
    public partial class Status
    {
        public Status()
        {
            Fleets = new HashSet<Fleet>();
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Fleet> Fleets { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
