using System.ComponentModel.DataAnnotations;

namespace DbTableEditor.Data.Model
{
    [DisplayColumn(nameof(Name))]
    public partial class Commander
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        public int Age { get; set; }
        public virtual Fleet Fleet { get; set; }
        public virtual Rank Rank { get; set; }
        public int RankId { get; set; }
        public int Skill { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
