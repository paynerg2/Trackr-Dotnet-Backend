using System.ComponentModel.DataAnnotations;

namespace Trackr.Data
{
    public class Contact
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string? Email { get; set; }
        public string? Position { get; set; }
        public string? Phone { get; set; }
    }
}
