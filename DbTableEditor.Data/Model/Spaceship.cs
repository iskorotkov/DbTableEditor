using System.ComponentModel.DataAnnotations;

namespace DbTableEditor.Data.Model
{
    [DisplayColumn(nameof(Name))]
    public partial class Spaceship
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(0, int.MaxValue)]
        public int Capacity { get; set; }

        [Range(0, int.MaxValue)]
        public int Energy { get; set; }

        [Range(0, int.MaxValue)]
        public int Firepower { get; set; }

        public virtual Fleet Fleet { get; set; }

        [ValidId]
        public int FleetId { get; set; }

        [Range(0, int.MaxValue)]
        public int Fuel { get; set; }

        [Range(0, int.MaxValue)]
        public int Hull { get; set; }


        public virtual Shipyard Shipyard { get; set; }

        [ValidId]
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
