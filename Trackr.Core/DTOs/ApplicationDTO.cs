using System.ComponentModel.DataAnnotations;
using Trackr.Data.Utils.Types;

namespace Trackr.Core.DTOs
{
    public class ApplicationDTO : UpdateApplicationDTO
    {
        public string Id { get; set; }

        public bool Temp { get; set; } = false;
        public bool ArbitraryRelocation { get; set; } = false;
        public string JobDescriptionLink { get; set; } = String.Empty;
        public bool GivenReferral { get; set; } = false;
        public string CompanyLinkedIn { get; set; } = String.Empty;
        public string Field { get; set; } = String.Empty;
        
        
    }

    public class CreateApplicationDTO
    {
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

        public string Location { get; set; } = String.Empty;
        public string MainSkill { get; set; } = String.Empty;
        public DateTime DatePosted { get; set; }
        public DateTime DateApplicationSent { get; set; } = DateTime.Now;

    }

    public class UpdateApplicationDTO : CreateApplicationDTO
    {
        [RegularExpression(ApplicationResponseType.Fields)]
        public string Response { get; set; } = ApplicationResponseType.NoResponse;

        public virtual ICollection<CreateInterviewDTO> Interviews { get; set; }
    }
}
