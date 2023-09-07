using System.ComponentModel.DataAnnotations;

namespace BooksManagementSystem.DTOs
{
    public class UserForRegistrationDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required(ErrorMessage = "User name is required")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage ="Email is required")]
        public string Email { get; set; }
    }
}
