namespace JobApplication_software_design.Models
{
    public class JobCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<JobPosting> JobPosting { get; set; }
        public int JobPostingId { get; set; }


        // Aggregation with JobPosting is represented by not including a foreign key back to JobPosting.
        // Instead, JobPosting will hold a foreign key to JobCategory.

        // Additional methods or properties relevant to JobCategory can be added here
    }
}
