using System;

namespace JobApplication_software_design.Models
{
    public class Interview : IInterview // Implementing the IInterview interface
    {
        public int Id { get; set; }
        
        // Foreign key for JobApplication - represents the association with JobApplication
        

        // Navigation property for JobApplication - to access the related JobApplication object
        public JobApplication JobApplication { get; set; }
        public int JobApplicationId { get; set; }

        protected User Interviewer { get; set; }
        protected DateTime Date { get; set; }
        public string Location { get; set; }
        public string Notes { get; set; }

        public IEnumerable<PhoneInterview> PhoneInterview { get; set; }
        public int PhoneInterviewId { get; set; }

        public IEnumerable<InPersonInterview> InPersonInterview { get; set; }
        public int InPersonInterviewId { get; set; }
        public virtual void ScheduleInterview()
        {
            // Implement the logic to schedule an interview
        }

        public virtual void RemoveInterview()
        {
            // Implement the logic to remove a scheduled interview
        }
    }
}
