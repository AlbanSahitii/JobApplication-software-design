using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;

namespace JobApplication_software_design.Models
{
    /*public class User
    {
        // Assume that this class has its own properties and methods, which are not detailed in the UML diagram.
    }*/

    public class Resume //:IResume
    {
        public int Id { get; set; }
        private User User { get; set; } // This field is private, so it's only accessible within this class.
        protected string Content { get; set; } // This field is protected, so it's accessible within this class and any derived classes.
        public DateTime LastUpdated { get; set; }
        public string Title { get; set; }

        public void AddPersonalInfo()
        {
            // Logic to add personal information to the resume
        }

        public void AddEducation()
        {
            // Logic to add educational background to the resume
        }

        public void AddWorkExperience()
        {
            // Logic to add work experience to the resume
        }

        public void AddSkill()
        {
            // Logic to add skills to the resume
        }

        public string GetResumeDetails()
        {
            // Logic to retrieve and return the resume details
            return Content; // Assuming that 'Content' holds the full details of the resume
        }
    }
}
