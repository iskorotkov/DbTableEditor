using System;
using System.Collections.Generic;

namespace DbTableEditor.WPF
{
    public partial class StarTypes
    {
        public StarTypes()
        {
            Stars = new HashSet<Stars>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Stars> Stars { get; set; }
    }
}
