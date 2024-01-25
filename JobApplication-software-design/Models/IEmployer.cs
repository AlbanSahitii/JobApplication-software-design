namespace JobApplication_software_design.Models
{
    public interface IEmployer
    {
        // Interfaces in C# can contain methods but typically do not contain properties
        // that have setters or getters as they do not hold state.

        // Method to post a new job
        void PostJob();

        // Method to remove an existing job
        void RemoveJob();
    }
}
