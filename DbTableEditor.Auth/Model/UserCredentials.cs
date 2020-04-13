using System.ComponentModel.DataAnnotations;

namespace DbTableEditor.Auth.Model
{
    public class UserCredentials
    {
        [Required] [EmailAddress] public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required] public string Role { get; set; }
    }
}
