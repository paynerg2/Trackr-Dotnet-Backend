using System.ComponentModel.DataAnnotations;
using Trackr.Data.Utils.Types;

namespace Trackr.Core.DTOs
{
    public class InterviewDTO : UpdateInterviewDTO
    {
        public string Id { get; set; }

        public string Notes { get; set; } = String.Empty;
        public bool FollowUpSent { get; set; } = false;
        public CreateContactDTO? Contact { get; set; }
    }

    public class CreateInterviewDTO
    {
        [Required]
        public DateTime StartTime { get; set; }

        public string Location { get; set; } = String.Empty;
        public string Company { get; set; } = String.Empty;
        public string InterviewType { get; set; } = String.Empty;

    }

    public class UpdateInterviewDTO : CreateInterviewDTO 
    {
        [Range(1, 10)]
        public int Round { get; set; } = 1;

        [RegularExpression(InterviewResponseType.Fields)]
        public string Response { get; set; } = InterviewResponseType.None;

        [Range(0, Int32.MaxValue)]
        public int Offer { get; set; } = 0;
    }
}
