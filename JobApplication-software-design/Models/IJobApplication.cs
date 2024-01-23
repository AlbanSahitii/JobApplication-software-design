namespace JobApplication_software_design.Models
{
    public interface IJobApplication
    {
        int Id { get; }
        void ApplyForJob();
        void CancelApplication();
    }
}
