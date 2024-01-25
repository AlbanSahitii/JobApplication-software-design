namespace JobApplication_software_design.Models
{
    public interface IResume
    {
        // Method to add personal information to the resume
        void AddPersonalInfo(string personalInfo);

        // Method to add educational background to the resume
        void AddEducation();

        // Method to add work experience to the resume
        void AddWorkExperience();

        // Method to add skills to the resume
        void AddSkill();

        // Method to retrieve and return resume details
        string GetResumeDetails();
    }
}
