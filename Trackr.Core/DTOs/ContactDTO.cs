using System.ComponentModel.DataAnnotations;

namespace Trackr.Core.DTOs
{
    public class ContactDTO : CreateContactDTO
    {
        public string Id { get; set; }
    }

    public class CreateContactDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Company { get; set; }

        public string Email { get; set; } = String.Empty;
        public string Position { get; set; } = String.Empty;
        public string Phone { get; set; } = String.Empty;
    }

    public class UpdateContactDTO : CreateContactDTO
    {

    }
}
