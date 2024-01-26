namespace JobApplication_software_design.Models
{
    // PhoneInterview inherits from Interview, indicating an aggregation relationship
    public class PhoneInterview : Interview, IInterview // Implementing the IInterview interface
    {
        public string DialInNumber { get; set; }
        private int Duration { get; set; } // Assuming this should be a private field

        // Foreign key for JobApplication - represents the association with JobApplication
        //public int JobApplicationId { get; set; }

        // Navigation property for JobApplication - to access the related JobApplication object
        public JobApplication JobApplication { get; set; }

        public Interview Interview { get; set; }
        public int InterviewId { get; set; }

        public void AddPhoneInterview()
        {
            // Implement the logic to add a phone interview
            // This might involve setting initial values, scheduling the interview, etc.
        }

        // Implementation of IInterview interface methods
        public override void ScheduleInterview()
        {
            // Implement the logic to schedule a phone interview
        }

        public override void RemoveInterview()
        {
            // Implement the logic to remove a scheduled phone interview
        }
    }
}
