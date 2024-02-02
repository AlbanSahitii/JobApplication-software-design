namespace JobApplication_software_design.Models
{
    public class Employer : IEmployer // Implementing the IEmployer interface
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Industry { get; set; }
        public string Location { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }

        // Assuming that Employer has an association with JobPosting
        // A list to hold the association with JobPostings
        public virtual ICollection<JobPosting>? JobPostings { get; set; }

        // Implementation of IEmployer interface methods
        public void PostJob()
        {
            // Implement the logic to post a new job listing by the employer
        }

        public void RemoveJob()
        {
            // Implement the logic to remove an existing job listing
        }
    }
}
