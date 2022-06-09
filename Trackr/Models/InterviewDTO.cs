using System.ComponentModel.DataAnnotations;
using Trackr.Utils.Types;

namespace Trackr.Models
{
    public class InterviewDTO
    {
        public string Id { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [RegularExpression(InterviewResponseType.Fields)]
        public string Response { get; set; } = InterviewResponseType.None;


        [Range(1, 10)]
        public int Round { get; set; } = 1;

        [Range(0, Int32.MaxValue)]
        public int Offer { get; set; } = 0;

        public string Location { get; set; } = String.Empty;
        public string Company { get; set; } = String.Empty;
        public string InterviewType { get; set; } = String.Empty;
        public string Notes { get; set; } = String.Empty;
        public bool FollowUpSent { get; set; } = false;
        public ContactDTO? Contact { get; set; }
    }
}
