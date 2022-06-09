using System.ComponentModel.DataAnnotations;
using Trackr.Utils.Types;

namespace Trackr.Models
{
    public class ApplicationDTO
    {
        public string Id { get; set; }

        [Required]
        public string Company { get; set; }

        [Range(0, Int32.MaxValue, ErrorMessage = "{0} must be non-negative.")]
        public int RequiredSkillsTotal { get; set; } = 0;

        [Range(0, Int32.MaxValue, ErrorMessage = "{0} must be non-negative.")]
        public int RequiredSkillsMet { get; set; } = 0;

        [Range(0, Int32.MaxValue, ErrorMessage = "{0} must be non-negative.")]
        public int AdditionalSkillsTotal { get; set; } = 0;

        [Range(0, Int32.MaxValue, ErrorMessage = "{0} must be non-negative.")]
        public int AdditionalSkillsMet { get; set; } = 0;

        [Range(0, Int32.MaxValue, ErrorMessage = "{0} must be non-negative.")]
        public int YearsOfExperience { get; set; } = 0;

        [Range(0, Int32.MaxValue, ErrorMessage = "{0} must be non-negative.")]

        public int ExpectedSalary { get; set; } = 0;

        [RegularExpression(DegreeType.Fields)]
        public string DegreeLevel { get; set; } = DegreeType.None;

        [RegularExpression(ApplicationResponseType.Fields)]
        public string Response { get; set; } = ApplicationResponseType.NoResponse;

        public bool Temp { get; set; } = false;
        public bool ArbitraryRelocation { get; set; } = false;
        public string JobDescriptionLink { get; set; } = String.Empty;
        public string Location { get; set; } = String.Empty;
        public string MainSkill { get; set; } = String.Empty;
        public DateTime DatePosted { get; set; }
        public DateTime DateApplicationSent { get; set; } = DateTime.Now;
        public bool GivenReferral { get; set; } = false;
        public string CompanyLinkedIn { get; set; } = String.Empty;
        
        public string Field { get; set; } = String.Empty;
        
        public virtual ICollection<InterviewDTO> Interviews { get; set; }
    }
}
