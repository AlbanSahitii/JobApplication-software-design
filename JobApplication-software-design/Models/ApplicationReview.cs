using System;

namespace JobApplication_software_design.Models
{
    /*public enum ApplicationStatus
    {
        Pending,
        Approved,
        Rejected
    }*/

    /*public class JobApplication
    {
        // Define the JobApplication class properties and methods
        // ...
    }*/


    public class ApplicationReview
    {
        public int Id { get; set; }
        public JobApplication JobApplication { get; set; }
        public User Reviewer { get; set; }
        public string Feedback { get; set; }
        public DateTime Date { get; set; }
        public ApplicationStatus Status { get; set; }

        public void ReviewApplication()
        {
            // Implement the review logic here
        }
    }
}
