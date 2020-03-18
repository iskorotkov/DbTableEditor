using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DbTableEditor.Data.Model
{
    [DisplayColumn(nameof(Name))]
    public partial class Star
    {
        public Star()
        {
            Planets = new HashSet<Planet>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public long Age { get; set; }
        public virtual ICollection<Planet> Planets { get; set; }
        public int Size { get; set; }
        public virtual StarType Type { get; set; }
        public int TypeId { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
