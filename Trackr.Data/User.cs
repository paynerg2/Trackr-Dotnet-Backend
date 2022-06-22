using Microsoft.AspNetCore.Identity;

namespace Trackr.Data
{
    public class User : IdentityUser
    {
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? Location { get; set; }
        public string? FullName { get; set; }
        public string? CloudinaryId { get; set; }
        public string? ProfileImage { get; set; }
        public ICollection<Application> Applications { get; set; } = new List<Application>();
        public ICollection<Interview> Interviews { get; set; } = new List<Interview>();
        public ICollection<Contact> Contacts { get; set; } = new List<Contact>();
        public Settings Settings { get; set; } = new Settings();

    }
}
