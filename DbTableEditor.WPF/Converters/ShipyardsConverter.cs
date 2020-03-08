using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using DbTableEditor.Data.Context;
using DbTableEditor.Data.Model;

namespace DbTableEditor.WPF.Converters
{
    public class ShipyardsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var list = (List<Shipyard>)value;
            return list.Select(e => e.Name);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var list = (List<string>)value;
            using var context = new SpaceshipsContext();
            return list
                .Select(name => context.Shipyards.First(e => e.Name == name))
                .ToList();
        }
    }
}
