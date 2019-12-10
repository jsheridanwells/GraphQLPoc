using System.ComponentModel.DataAnnotations;

namespace GQL.UserService.Domain.Models
{
    public class UserRegistration
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Not a valid email address.")]
        public string Email { get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters.")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Password and Password Confirmation do not match.")]
        public string PasswordConfirmation { get; set; }
    }
}
