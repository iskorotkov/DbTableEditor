using System;
using System.Collections.Generic;

namespace DbTableEditor.WPF
{
    public partial class Shipyards
    {
        public Shipyards()
        {
            Spaceships = new HashSet<Spaceships>();
        }

        public int Id { get; set; }
        public int Pipelines { get; set; }
        public int Staff { get; set; }
        public int PlanetId { get; set; }
        public string Name { get; set; }

        public virtual Planets Planet { get; set; }
        public virtual ICollection<Spaceships> Spaceships { get; set; }
    }
}
