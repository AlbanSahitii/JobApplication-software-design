using System;

namespace JobApplication_software_design.Models
{
    public class CoverLetter
    {
        public int Id { get; set; }

        // Foreign key for User
        // This assumes that the CoverLetter is associated with a User.
        //public string UserId { get; set; }

        // Navigation property for User
        // This represents an association with the User who created the cover letter.
        public User? User { get; set; }

        // Foreign key for JobApplication
        // This is part of the composition relationship with JobApplication.
        public int? JobApplicationId { get; set; }

        // Navigation property for JobApplication
        // This indicates that CoverLetter is a component of JobApplication.
        public JobApplication? JobApplication { get; set; }

        public string Content { get; set; }
        public DateTime LastUpdated { get; set; } = DateTime.Now;
        public string Title { get; set; }

        public void AddCoverLetter()
        {
            // Implement the logic to add a cover letter
            // This might involve setting initial values or adding the cover letter to a database
        }
    }
}
