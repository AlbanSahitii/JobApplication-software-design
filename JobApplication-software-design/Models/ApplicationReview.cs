using System;

namespace JobApplication_software_design.Models
{
    public class ApplicationReview
    {
        public int Id { get; set; }

        // Foreign key for JobApplication (Composition)
        public int? JobApplicationId { get; set; }

        // Navigation property for JobApplication (Composition)
        // This indicates a strong lifecycle dependency on JobApplication.
        public JobApplication? JobApplication { get; set; }

        // Foreign key for User (Reviewer)
        public string? ReviewerId { get; set; }

        // Navigation property for User (Reviewer)
        // This represents an association but with independent lifecycles.
        public User? Reviewer { get; set; }

        public string Feedback { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        // Foreign key for ApplicationStatus
       // public int ApplicationStatusId { get; set; }

        // Navigation property for ApplicationStatus
        // Indicates that ApplicationReview includes ApplicationStatus as part of its state.
        //public ApplicationStatus Status { get; set; }

        public void ReviewApplication()
        {
            // Implement the review logic here
        }
    }
}
