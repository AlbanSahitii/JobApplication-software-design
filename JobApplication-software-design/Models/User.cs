using Microsoft.AspNetCore.Identity;

namespace JobApplication_software_design.Models
{
    public class User : IdentityUser
    {
        public string Firstname {  get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string Picture {  get; set; }
        public string Skills { get; set; }
        public string Education { get; set; }
          
    }
}
