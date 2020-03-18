using System.ComponentModel.DataAnnotations;

namespace DbTableEditor.Data.Model
{
    [DisplayColumn(nameof(Name))]
    public partial class Planet
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int? Approval { get; set; }
        public virtual Empire Empire { get; set; }
        public int? EmpireId { get; set; }
        public int Habitability { get; set; }
        public long Population { get; set; }
        public virtual Shipyard Shipyards { get; set; }
        public int Size { get; set; }
        public virtual Star Star { get; set; }
        public int StarId { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
