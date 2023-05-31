using Microsoft.AspNetCore.Identity;

namespace Stud_io.StudyGroups.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char Gender { get; set; }
    }
}
