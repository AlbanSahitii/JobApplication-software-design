using System;

namespace JobApplication_software_design.Models
{
    /*public class JobApplication
    {
        // Define the JobApplication class properties and methods
        // ...
    }

    public class User
    {
        // Define the User class properties and methods
        // ...
    }*/

    public class Interview
    {
        public int Id { get; set; }
        private JobApplication jobApplication; // Assuming a one-to-one relationship
        protected User Interviewer { get; set; }
        protected DateTime Date { get; set; }
        public string Location { get; set; }
        public string Notes { get; set; }

        public void ScheduleInterview()
        {
            // Implement the logic to schedule an interview
        }

        public void RemoveInterview()
        {
            // Implement the logic to remove a scheduled interview
        }
    }
}
