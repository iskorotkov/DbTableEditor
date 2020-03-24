using System;
using System.ComponentModel.DataAnnotations;

namespace DbTableEditor.Data
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class ValidIdAttribute : ValidationAttribute
    {
        public int LastCharactersToRemove { get; set; } = 2;

        public override bool IsValid(object value)
        {
            return value is int id && id > 0;
        }

        public override string FormatErrorMessage(string name)
        {
            return $"The {name[0..^LastCharactersToRemove]} field is required.";
        }
    }
}
