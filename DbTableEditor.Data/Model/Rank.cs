using System.Collections.Generic;

namespace DbTableEditor.Data.Model
{
    public partial class Rank
    {
        public Rank()
        {
            Commanders = new HashSet<Commander>();
        }

        public virtual ICollection<Commander> Commanders { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
