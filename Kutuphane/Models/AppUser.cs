namespace Kutuphane.Models
{
    public class AppUser
    {

        public int AppUserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public bool MustChangePassword { get; set; } = true;



        public string PasswordHash { get; set; }= string.Empty;

        public UserRole Role { get; set; }

        public Student? Student { get; set; } 


    }
}
