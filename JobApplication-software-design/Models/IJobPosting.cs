namespace JobApplication_software_design.Models
{
    public interface IJobPosting
    {
        public int ID { get; set; }
        public void createJobPost();
        public void updateJobPost();
        public void removeJobPost();

    }
}
