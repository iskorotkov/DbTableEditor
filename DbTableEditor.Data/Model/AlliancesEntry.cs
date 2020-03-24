using System.ComponentModel.DataAnnotations;

namespace DbTableEditor.Data.Model
{
    public partial class AlliancesEntry
    {
        public int Id { get; set; }
        public virtual Alliance Alliance { get; set; }
        [ValidId]
        public int AllianceId { get; set; }
        public virtual Empire Empire { get; set; }
        [ValidId]
        public int EmpireId { get; set; }
        [Range(0, int.MaxValue)]
        public int EntryYear { get; set; }
    }
}
