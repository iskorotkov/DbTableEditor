using DbTableEditor.Data.Context;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace DbTableEditor.WPF.Converters
{
    public abstract class BaseConverter<T> : IValueConverter
    {
        public abstract List<T> GetItems();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var list = (List<T>)value;
            return list.Select(e => (e as dynamic).Name);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var list = (List<string>)value;
            var items = GetItems();
            using var context = new SpaceshipsContext();
            return list
                .Select(name => items.First(e => (e as dynamic).Name == name))
                .ToList();
        }
    }
}
