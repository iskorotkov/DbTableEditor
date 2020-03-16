using System;
using System.ComponentModel.DataAnnotations;

namespace DbTableEditor.Data
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class ValidIdAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return value is int id && id > 0;
        }

        public override string FormatErrorMessage(string name)
        {
            return $"The {name[0..^2]} field is required.";
        }
    }
}
