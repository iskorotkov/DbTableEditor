using System.Collections.Generic;

namespace DbTableEditor.WPF.Model
{
    public partial class StarType
    {
        public StarType()
        {
            Stars = new HashSet<Star>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Star> Stars { get; set; }
    }
}
