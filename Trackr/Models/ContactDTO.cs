using System.ComponentModel.DataAnnotations;

namespace Trackr.Models
{
    public class ContactDTO
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Company { get; set; }

        public string Email { get; set; } = String.Empty;
        public string Position { get; set; } = String.Empty;
        public string Phone { get; set; } = String.Empty;
    }
}
