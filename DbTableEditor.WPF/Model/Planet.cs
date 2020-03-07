namespace DbTableEditor.WPF.Model
{
    public partial class Planet
    {
        public int? Approval { get; set; }
        public virtual Empire Empire { get; set; }
        public int? EmpireId { get; set; }
        public int Habitability { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
        public virtual Shipyard Shipyards { get; set; }
        public int Size { get; set; }
        public virtual Star Star { get; set; }
        public int StarId { get; set; }
    }
}
