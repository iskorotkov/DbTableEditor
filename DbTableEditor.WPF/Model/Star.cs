using System.Collections.Generic;

namespace DbTableEditor.WPF.Model
{
    public partial class Star
    {
        public Star()
        {
            Planets = new HashSet<Planet>();
        }

        public int Age { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Planet> Planets { get; set; }
        public int Size { get; set; }
        public virtual StarType Type { get; set; }
        public int TypeId { get; set; }
    }
}
