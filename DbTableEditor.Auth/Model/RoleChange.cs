using System.ComponentModel.DataAnnotations;

namespace DbTableEditor.Auth.Model
{
    public class RoleChange
    {
        public string UserId { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
