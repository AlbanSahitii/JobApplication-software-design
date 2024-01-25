namespace JobApplication_software_design.Models
{
    public interface IInterview
    {
        // Method to schedule an interview
        void ScheduleInterview();

        // Method to remove a scheduled interview
        void RemoveInterview();
    }
}
