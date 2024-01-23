namespace JobApplication_software_design.Models
{
    /*public class User
    {
        // Define the User class properties and methods
        // ...
    }*/

    public class CoverLetter
    {
        public int Id { get; set; }
        public User User { get; set; } // Assuming this represents the user who created the cover letter
        public string Content { get; set; }
        public DateTime LastUpdated { get; set; }
        public string Title { get; set; }

        public void AddCoverLetter()
        {
            // Implement the logic to add a cover letter
            // This might involve setting initial values or adding the cover letter to a database
        }
    }
}
