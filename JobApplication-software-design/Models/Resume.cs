using System.Runtime.CompilerServices;

namespace JobApplication_software_design.Models
{
    // Resume class implementing IResume interface
    public class Resume : IResume
    {
        public int ResumeId { get; set; }
        public string FilePath { get; set; }
        public DateTime LastUpdated { get; set; }
        public string Skills { get; set; }

        // Foreign key for JobApplication - represents the composition with JobApplication
        public int JobApplicationId { get; set; }

        // Navigation property for JobApplication - to access the related JobApplication object
        public JobApplication JobApplication { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public Resume()
        {
            LastUpdated = DateTime.Now;
        }

        
       public void AddPersonalInfo(string personalInfo)
        {

        }

        // Method to add educational background to the resume
        public void AddEducation()
        {

        }

        // Method to add work experience to the resume
        public void AddWorkExperience()
        {

        }

        // Method to add skills to the resume
        public  void AddSkill()
        {

        }

        // Method to retrieve and return resume details
        public string GetResumeDetails()
        {
            string resumeDetails = string.Empty;

            //Fill Datas

            return resumeDetails;
        }




    }
}
