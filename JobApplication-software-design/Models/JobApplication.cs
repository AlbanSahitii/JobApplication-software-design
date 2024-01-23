
using System;

namespace JobApplication_software_design.Models
{
   /* public enum ApplicationStatus
    {
        Pending,
        Approved,
        Rejected
    }*/

    

    /*public class JobPosting
    {
        // Define the JobPosting class properties and methods
        // ...
    }

    public class CoverLetter
    {
        // Define the CoverLetter class properties and methods
        // ...
    }*/

    public class JobApplication
    {
        public int Id { get; set; }
        public User User { get; set; }
        public JobPosting JobPosting { get; set; }
        public ApplicationStatus Status { get; set; }
        public DateTime SubmissionDate { get; set; }
        public DateTime LastUpdated { get; set; }
        public string Notes { get; set; }
        public CoverLetter CoverLetter { get; set; }

        public void ApplyForJob()
        {
            // Implement the apply logic here
        }

        public void CancelApplication()
        {
            // Implement the cancel logic here
        }
    }
}

