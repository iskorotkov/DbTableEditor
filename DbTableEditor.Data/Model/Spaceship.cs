using System.ComponentModel.DataAnnotations;

namespace DbTableEditor.Data.Model
{
    public partial class Spaceship
    {
        [Range(0, int.MaxValue)]
        public int Capacity { get; set; }

        [Range(0, int.MaxValue)]
        public int Energy { get; set; }

        [Range(0, int.MaxValue)]
        public int Firepower { get; set; }

        [Required]
        public virtual Fleet Fleet { get; set; }

        public int FleetId { get; set; }

        [Range(0, int.MaxValue)]
        public int Fuel { get; set; }

        [Range(0, int.MaxValue)]
        public int Hull { get; set; }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public virtual Shipyard Shipyard { get; set; }

        public int ShipyardId { get; set; }

        [Range(0, int.MaxValue)]
        public int Speed { get; set; }

        [Range(0, int.MaxValue)]
        public int Staff { get; set; }

        [Range(0, int.MaxValue)]
        public int Weight { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
