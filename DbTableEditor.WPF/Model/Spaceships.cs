using System;
using System.Collections.Generic;

namespace DbTableEditor.WPF
{
    public partial class Spaceships
    {
        public int Id { get; set; }
        public int Speed { get; set; }
        public int Capacity { get; set; }
        public int Weight { get; set; }
        public int Energy { get; set; }
        public int Firepower { get; set; }
        public int Hull { get; set; }
        public int Staff { get; set; }
        public int Fuel { get; set; }
        public int FleetId { get; set; }
        public int ShipyardId { get; set; }
        public string Name { get; set; }

        public virtual Fleets Fleet { get; set; }
        public virtual Shipyards Shipyard { get; set; }
    }
}
