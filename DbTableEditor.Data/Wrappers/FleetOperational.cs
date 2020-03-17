using DbTableEditor.Data.Model;

namespace DbTableEditor.Data.Wrappers
{
    public class FleetOperational
    {
        public Fleet Fleet { get; set; }
        public bool HasShips { get; set; }

        public FleetOperational()
        {

        }

        public FleetOperational(Fleet fleet, bool hasShips)
        {
            Fleet = fleet;
            HasShips = hasShips;
        }

        public void Deconstruct(out Fleet fleet, out bool hasShips)
        {
            fleet = Fleet;
            hasShips = HasShips;
        }
    }
}
