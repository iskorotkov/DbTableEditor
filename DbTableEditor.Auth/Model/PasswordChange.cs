using System.ComponentModel.DataAnnotations;

namespace DbTableEditor.Auth.Model
{
    public class PasswordChange
    {
        public string UserId { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
