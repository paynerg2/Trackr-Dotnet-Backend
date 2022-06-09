using System.ComponentModel.DataAnnotations;

namespace Trackr.Models
{
    public class UserDTO : LoginUserDTO
    {
        public string FullName { get; set; } = String.Empty;
        public string Location { get; set; } = String.Empty;
    }

    public class LoginUserDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
