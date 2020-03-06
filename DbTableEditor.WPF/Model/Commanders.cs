using System;
using System.Collections.Generic;

namespace DbTableEditor.WPF
{
    public partial class Commanders
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public int Skill { get; set; }
        public int RankId { get; set; }

        public virtual Ranks Rank { get; set; }
        public virtual Fleets Fleets { get; set; }
    }
}
