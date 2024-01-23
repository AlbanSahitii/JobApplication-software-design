namespace JobApplication_software_design.Models
{
    // Assuming In-PersonInterview inherits from a base Interview class
    public class InPersonInterview : Interview
    {
        protected string InterviewerFeedback { get; set; }
        public string Location { get; set; }

        public void AddInPersonInterview()
        {
            // Implement the logic to add an in-person interview
            // This could involve scheduling the interview, setting the location, etc.
        }
    }
}
