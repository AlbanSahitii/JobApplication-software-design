namespace JobApplication_software_design.Models
{
    public interface IJobPosting
    {
        // Method to create a job posting
        void CreateJobPost();

        // Method to update an existing job posting
        void UpdateJobPost();

        // Method to remove a job posting
        void RemoveJobPost();
    }
}
