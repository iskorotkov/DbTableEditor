using System;
using System.Collections.Generic;

namespace DbTableEditor.WPF
{
    public partial class AlliancesEntries
    {
        public int Id { get; set; }
        public int AllianceId { get; set; }
        public int EmpireId { get; set; }
        public int EntryYear { get; set; }

        public virtual Alliances Alliance { get; set; }
        public virtual Empires Empire { get; set; }
    }
}
