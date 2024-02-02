namespace JobApplication_software_design.Models
{
    public class ApplicationStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public JobApplication? JobApplication { get; set; }

        public int? JobApplicationId { get; set; }

        // This class is used in a composition relationship with JobApplication.
        // However, in this specific case, it's not typical to include a foreign key back to JobApplication
        // because ApplicationStatus can be a shared resource across multiple JobApplications.
        // If your design requires a direct link back to a specific JobApplication, include a foreign key.
        // public int JobApplicationId { get; set; } // Uncomment if needed

        public string GetApplicationStatus()
        {
            // Implement the logic to get the application status details
            // For example, it could return a string representation of the status
            return $"Status: {Name} - {Description}";
        }
    }
}
