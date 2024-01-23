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
    }
}

