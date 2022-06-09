using System.ComponentModel.DataAnnotations;
using Trackr.Utils.Types;

namespace Trackr.Data
{
    public class Interview
    {
        public string Id { get; set; }
        public DateTime StartTime { get; set; }
        public string Response { get; set; } = InterviewResponseType.None;
        public bool FollowUpSent { get; set; } = false;
        public int Round { get; set; } = 1;
        public string Location { get; set; } = String.Empty;
        public Contact? Contact { get; set; }
        public string Company { get; set; } = String.Empty;
        public int Offer { get; set; } = 0;
        public string InterviewType { get; set; } = String.Empty;
        public string Notes { get; set; } = String.Empty;
    }
}
