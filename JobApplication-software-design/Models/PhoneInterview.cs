namespace JobApplication_software_design.Models
{
    public class InPhoneInterview
    {
        public int Id { get; set; }
        private int Duration { get; set; } // Assuming this should be a private field based on the UML diagram
        public string DialInNumber { get; set; }

        public void AddPhoneInterview()
        {
            // Implement the logic to add a phone interview
            // This might involve setting initial values, scheduling the interview, etc.
        }
    }
}
