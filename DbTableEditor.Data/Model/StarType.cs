using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DbTableEditor.Data.Model
{
    [DisplayColumn(nameof(Name))]
    public partial class StarType
    {
        public StarType()
        {
            Stars = new HashSet<Star>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Star> Stars { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
