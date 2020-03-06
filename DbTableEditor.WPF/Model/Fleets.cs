using System;
using System.Collections.Generic;

namespace DbTableEditor.WPF
{
    public partial class Fleets
    {
        public Fleets()
        {
            Spaceships = new HashSet<Spaceships>();
        }

        public int Id { get; set; }
        public int StatusId { get; set; }
        public int? CommanderId { get; set; }
        public string Name { get; set; }

        public virtual Commanders Commander { get; set; }
        public virtual Statuses Status { get; set; }
        public virtual ICollection<Spaceships> Spaceships { get; set; }
    }
}
