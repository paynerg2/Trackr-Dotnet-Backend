using System.ComponentModel.DataAnnotations;
using Trackr.Utils.Types;

namespace Trackr.Data
{
    public class Application
    {
        public string Id { get; set; }
        public string Company { get; set; }
        public string JobDescriptionLink { get; set; } = String.Empty;
        public int RequiredSkillsTotal { get; set; } = 0;
        public int RequiredSkillsMet { get; set; } = 0;
        public int AdditionalSkillsTotal { get; set; } = 0;
        public int AdditionalSkillsMet { get; set; } = 0;
        public int YearsOfExperience { get; set; } = 0;
        public string DegreeLevel { get; set; } = DegreeType.None;
        public bool Temp { get; set; } = false;
        public bool ArbitraryRelocation { get; set; } = false;
        public string Location { get; set; } = String.Empty;
        public string MainSkill { get; set; } = String.Empty;
        public DateTime DatePosted { get; set; }
        public DateTime DateApplicationSent { get; set; } = DateTime.Now;
        public bool GivenReferral { get; set; } = false;
        public string CompanyLinkedIn { get; set; } = String.Empty;
        public int ExpectedSalary { get; set; } = 0;
        public string Field { get; set; } = String.Empty;
        public string Response { get; set; } = ApplicationResponseType.NoResponse;
        
        public virtual ICollection<Interview> Interviews { get; set; }
    }
}
