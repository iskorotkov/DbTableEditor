using System.ComponentModel.DataAnnotations;

namespace DbTableEditor.BlazorApp.Model
{
    public class RoleChange
    {
        [Required]
        public string Role { get; set; }
    }
}
