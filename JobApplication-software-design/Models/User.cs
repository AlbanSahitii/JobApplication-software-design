using Microsoft.AspNetCore.Identity;

namespace JobApplication_software_design.Models
{
    public class User : IdentityUser
    {
        public string Firstname {  get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string Picture {  get; set; }
        public string Skills { get; set; }
        public string Education { get; set; }
        public int ResumeId { get; set; }
        public IEnumerable<Resume> Resumes { get; set; }
        public int JobApplicationId { get; set; }
        public IEnumerable<JobApplication> JobApplications { get; set; }
        public IEnumerable <ApplicationReview> ApplicationReview { get; set; }
        public IEnumerable <CoverLetter> CoverLetter { get; set; }
        public int CoverLetterId { get; set; }
        public int ApplicationReviewID { get; set; }
        public void Login()
        {
            // Implementation of login
        }

        public void EditProfile()
        {
            // Implementation of profile editing
        }
    }
}
