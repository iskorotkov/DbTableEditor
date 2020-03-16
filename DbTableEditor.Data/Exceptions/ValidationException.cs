using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DbTableEditor.Data.Exceptions
{
    public class ValidationException : System.Exception
    {
        public ValidationException()
        {
        }

        public ValidationException(List<ValidationResult> errors) : base("Validation failed")
        {
            Errors = errors;
        }

        public ValidationException(List<ValidationResult> errors, System.Exception inner) : base("Validation failed", inner)
        {
            Errors = errors;
        }

        public List<ValidationResult> Errors { get; set; }
    }
}
