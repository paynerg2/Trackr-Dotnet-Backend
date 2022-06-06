using System.ComponentModel.DataAnnotations;

namespace Trackr.Models
{
    public class Interview
    {
        public string Id { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        public ResponseType Response { get; set; } = ResponseType.None;
        public Boolean FollowUpSent { get; set; } = false;
        public int Round { get; set; } = 1;
        public string? Location { get; set; }
        public Contact? Contact { get; set; }
        public string? Company { get; set; }
        public int? Offer { get; set; }
        public string? InterviewType { get; set; }
        public string? Notes { get; set; }
    }

    public enum ResponseType
    {
        None,
        Passed,
        Rejected,
        Offer
    }
}
