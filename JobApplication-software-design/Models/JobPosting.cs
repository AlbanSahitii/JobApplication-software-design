using System;
using System.Collections.Generic; // Required for using List

namespace JobApplication_software_design.Models
{
    public class JobPosting
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        // Foreign key for Employer - represents the association with Employer
        public int EmployerId { get; set; }

        // Navigation property for Employer
        public Employer Employer { get; set; }

        // Foreign key for JobCategory - represents the aggregation with JobCategory
        public int JobCategoryId { get; set; }

        // Navigation property for JobCategory
        public JobCategory JobCategory { get; set; }

        protected string Location { get; set; }
        public DateTime Deadline { get; set; }
        public string Requirements { get; set; }

        // Association with JobApplications
        public virtual ICollection<JobApplication> JobApplications { get; set; }

        public void CreateJobPost()
        {
            // Implement the logic to create a job posting
        }

        public void UpdateJobPost()
        {
            // Implement the logic to update a job posting
        }

        public void RemoveJobPost()
        {
            // Implement the logic to remove a job posting
        }
    }
}
