using System.ComponentModel.DataAnnotations;

namespace Trackr.Models
{
    public class Application
    {
        public string Id { get; set; }
        [Required]
        public string Company { get; set; }
        public string? JobDescriptionLink { get; set; }
        public int? RequiredSkillsTotal { get; set; }
        public int? RequiredSkillsMet { get; set; }
        public int? AdditionalSkillsTotal { get; set; }
        public int? AdditionalSkillsMet { get; set; }
        public int YearsOfExperience { get; set; } = 0;
        public DegreeType DegreeLevel { get; set; }
        public Boolean Temp { get; set; } = false;
        public Boolean ArbitraryRelocation { get; set; } = false;
        public string? Location { get; set; }
        public string? MainSkill { get; set; }
        public DateTime DatePosted { get; set; }
        public DateTime DateApplicationSent { get; set; } = DateTime.Now;
        public Boolean GivenReferral { get; set; } = false;
        public string? CompanyLinkedIn { get; set; }
        public int ExpectedSalary { get; set; } = 0;
        public string? Field { get; set; }
        public ApplicationResponseType Response { get; set; } = ApplicationResponseType.NoResponse;
        public ICollection<Interview> Interviews { get; set; }
    }

    public enum DegreeType
    {
        None,
        Associates,
        Bachelors,
        Masters,
        PhD
    }

    public enum ContractType
    {
        FullTime,
        PartTime,
        Contract,
        ContractToHire
    }

    public enum ApplicationResponseType
    {
        NoResponse,
        Rejected,
        Interview
    }
}
