using System.ComponentModel.DataAnnotations;

namespace CoffeSenja.API.ViewModels
{
    public class AuthViewModel
    {
        [Required, EmailAddress]
        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;
    }

    public class RegisterViewModel
    {
        public string Name { get; set; } = null!;

        [Required, EmailAddress]
        public string Email { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Password { get; set; } = null!;

        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; } = null!;

        public int Gender { get; set; }
    }
}