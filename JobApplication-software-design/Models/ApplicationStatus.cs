namespace JobApplication_software_design.Models
{
    public class ApplicationStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // This method could return some status-related data, or perhaps a list of all statuses.
        // The exact implementation will depend on your specific requirements.
        public string GetApplicationStatus()
        {
            // Implement the logic to get the application status details
            // For example, it could return a string representation of the status
            return $"Status: {Name} - {Description}";
        }
    }
}
