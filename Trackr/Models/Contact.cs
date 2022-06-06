using System.ComponentModel.DataAnnotations;

namespace Trackr.Models
{
    public class Contact
    {
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Company { get; set; }
        public string? Email { get; set; }
        public string? Position { get; set; }
        public string? Phone { get; set; }
    }
}
