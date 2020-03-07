namespace DbTableEditor.WPF.Model
{
    public partial class Spaceship
    {
        public int Capacity { get; set; }
        public int Energy { get; set; }
        public int Firepower { get; set; }
        public virtual Fleet Fleet { get; set; }
        public int FleetId { get; set; }
        public int Fuel { get; set; }
        public int Hull { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Shipyard Shipyard { get; set; }
        public int ShipyardId { get; set; }
        public int Speed { get; set; }
        public int Staff { get; set; }
        public int Weight { get; set; }
    }
}
