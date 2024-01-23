namespace JobApplication_software_design.Models
{
    public interface IEmployer
    {
        public int Id { get; set; }
        public void postJob();
        public void removeJob();
    }
}
