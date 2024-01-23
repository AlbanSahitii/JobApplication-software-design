using System;
namespace JobApplication_software_design.Models
{
    /*public class Employer
    {
        // Assuming this is meant to be 'Employer' and there is a typo.
        // Define the Employer class properties and methods
        // ...
    }

    public class JobCategory
    {
        // Define the JobCategory class properties and methods
        // ...
    }*/

    public class JobPosting
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        private Employer Employer { get; set; } // Assuming there's a typo in the UML class diagram ('Employe' should be 'Employer')
        public JobCategory JobCategory { get; set; }
        protected string Location { get; set; }
        public DateTime Deadline { get; set; }
        public string Requirements { get; set; }

        public void CreateJobPost()
        {
            // Implement the logic to create a job posting
        }

        public void UpdateJobPost()
        {
            // Implement the logic to update a job posting
        }

        public void RemoveJobPost()
        {
            // Implement the logic to remove a job posting
        }
    }
}
