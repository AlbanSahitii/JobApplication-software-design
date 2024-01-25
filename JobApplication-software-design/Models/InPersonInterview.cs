namespace JobApplication_software_design.Models
{
    // InPersonInterview inherits from Interview, indicating an aggregation relationship
    public class InPersonInterview : Interview, IInterview // Implementing the IInterview interface
    {
        // Additional properties specific to in-person interviews
        public string Location { get; set; }
        protected string InterviewerFeedback { get; set; }

        // Foreign key for JobApplication - represents the association with JobApplication
        public int JobApplicationId { get; set; }

        public Interview Interview { get; set; }
        public int InterviewId { get; set; }

        // Navigation property for JobApplication - to access the related JobApplication object
       //public JobApplication JobApplication { get; set; }

        public void AddInPersonInterview()
        {
            // Implement the logic to add an in-person interview
            // This could involve scheduling the interview, setting the location, etc.
        }

        // Implementation of IInterview interface methods
        public override void ScheduleInterview()
        {
            // Implement the logic to schedule an in-person interview
        }

        public override void RemoveInterview()
        {
            // Implement the logic to remove a scheduled in-person interview
        }
    }
}
