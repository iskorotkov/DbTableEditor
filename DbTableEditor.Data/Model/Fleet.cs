using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DbTableEditor.Data.Model
{
    [DisplayColumn(nameof(Name))]
    public partial class Fleet
    {
        public Fleet()
        {
            Spaceships = new HashSet<Spaceship>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public virtual Commander Commander { get; set; }

        [ValidId]
        public int CommanderId { get; set; }
        public virtual ICollection<Spaceship> Spaceships { get; set; }
        public virtual Status Status { get; set; }

        [ValidId]
        public int StatusId { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
