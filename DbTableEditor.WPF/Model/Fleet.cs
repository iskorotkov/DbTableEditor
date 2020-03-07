using System.Collections.Generic;

namespace DbTableEditor.WPF.Model
{
    public partial class Fleet
    {
        public Fleet()
        {
            Spaceships = new HashSet<Spaceship>();
        }

        public virtual Commander Commander { get; set; }
        public int CommanderId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Spaceship> Spaceships { get; set; }
        public virtual Statuses Status { get; set; }
        public int StatusId { get; set; }
    }
}
