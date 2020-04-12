using System.ComponentModel.DataAnnotations;

namespace DbTableEditor.BlazorApp.Model
{
    public class PasswordChange
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
