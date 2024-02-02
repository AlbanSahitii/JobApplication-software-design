using System;
using System.Collections.Generic; // Required for using List

namespace JobApplication_software_design.Models
{
    public class JobApplication : IJobApplication // Implementing the IJobApplication interface
    {
        public int Id { get; set; }

        // Foreign key for User
        public string? UserId { get; set; }

        // Navigation property for User
        public User? User { get; set; }

        // Foreign key for JobPosting
        public int? JobPostingId { get; set; }

        // Navigation property for JobPosting
        public JobPosting? JobPosting { get; set; }

        // Composition with ApplicationStatus
        public ApplicationStatus? Status { get; set; }

        // Composition with Resume
        public Resume? Resume { get; set; }

        // Composition with CoverLetter
        public CoverLetter? CoverLetter { get; set; }

        // Association with Interviews
        public virtual IEnumerable<Interview>? Interviews { get; set; }
        public int? InterviewId { get; set; }

        public DateTime SubmissionDate { get; set; } = DateTime.Now;
        public DateTime? LastUpdated { get; set; }
        public string Notes { get; set; }

        public ApplicationReview? ApplicationReview { get; set; }
        public int? ApplicationReviewId { get; set; }
        public int ResumeId { get; set; }

       // public ICollection<InPersonInterview> Interview { get; set; }


        public ApplicationStatus? ApplicationStatus { get; set; }
        public int? ApplicationStatusId { get; set; }

        public int CoverLetterId { get; set; }

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
