namespace JobApplication_software_design.Models
{
    public interface IInterview
    {
        int Id { get; } // Interfaces can contain properties, but these cannot have a setter.

        public void ScheduleInterview();

        public void RemoveInterview();
    }
}
