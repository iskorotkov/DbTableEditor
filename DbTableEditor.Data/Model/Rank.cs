using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DbTableEditor.Data.Model
{
    [DisplayColumn(nameof(Name))]
    public partial class Rank
    {
        public Rank()
        {
            Commanders = new HashSet<Commander>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Commander> Commanders { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
