using DbTableEditor.Data.Context;
using DbTableEditor.Data.Model;
using System.Collections.Generic;
using System.Linq;

namespace DbTableEditor.WPF.Converters
{
    public class ShipyardsConverter : BaseConverter<Shipyard>
    {
        public override List<Shipyard> GetItems()
        {
            using var context = new SpaceshipsContext();
            return context.Shipyards.ToList();
        }
    }
}
