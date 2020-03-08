using DbTableEditor.Data.Context;
using DbTableEditor.Data.Model;
using System.Collections.Generic;
using System.Linq;

namespace DbTableEditor.WPF.Converters
{
    public class FleetsConverter : BaseConverter<Fleet>
    {
        public override List<Fleet> GetItems()
        {
            using var context = new SpaceshipsContext();
            return context.Fleets.ToList();
        }
    }
}
