using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DbTableEditor.Data.Model
{
    [DisplayColumn(nameof(Name))]
    public partial class Shipyard
    {
        public Shipyard()
        {
            Spaceships = new HashSet<Spaceship>();
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Pipelines { get; set; }
        public virtual Planet Planet { get; set; }
        public int PlanetId { get; set; }
        public virtual ICollection<Spaceship> Spaceships { get; set; }
        public int Staff { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
