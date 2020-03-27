using System.ComponentModel.DataAnnotations;

namespace DbTableEditor.Auth.Model
{
    public class Person
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
