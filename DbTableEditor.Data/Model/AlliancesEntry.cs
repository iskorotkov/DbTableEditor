namespace DbTableEditor.Data.Model
{
    public partial class AlliancesEntry
    {
        public virtual Alliance Alliance { get; set; }
        public int AllianceId { get; set; }
        public virtual Empire Empire { get; set; }
        public int EmpireId { get; set; }
        public int EntryYear { get; set; }
        public int Id { get; set; }
    }
}
