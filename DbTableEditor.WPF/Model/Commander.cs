namespace DbTableEditor.WPF.Model
{
    public partial class Commander
    {
        public int Age { get; set; }
        public virtual Fleet Fleets { get; set; }
        public string Gender { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Rank Rank { get; set; }
        public int RankId { get; set; }
        public int Skill { get; set; }
    }
}
