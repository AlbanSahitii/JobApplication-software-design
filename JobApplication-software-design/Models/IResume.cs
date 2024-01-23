using System;

namespace JobApplication_software_design.Models
{
    public interface IResume
    {
        int Id { get; }
        void AddPersonalInfo();
        void AddEducation();
        void AddWorkExperience();
        void AddSkill();
        string GetResumeDetails();
    

    /*public class User
    {
        // Define the User class with its properties and methods
        // ...
    }

    public class Resume : IResume
    {
        public int Id { get; set; } // Implementation of IResume.Id
        public User User { get; set; }
        protected string Content { get; set; }
        public DateTime LastUpdated { get; set; }
        public string Title { get; set; }*/

        public void AddPersonalInfo()
        {
            // Implement the logic to add personal information to the resume
        }

        public void AddEducation()
        {
            // Implement the logic to add education details to the resume
        }

        public void AddWorkExperience()
        {
            // Implement the logic to add work experience to the resume
        }

        public void AddSkill()
        {
            // Implement the logic to add skills to the resume
        }

        public string GetResumeDetails()
        {
            // Implement the logic to retrieve and return resume details
            return Content; // This is a simple example, returning the content
        }
    }
}
}