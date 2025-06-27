using System.ComponentModel.DataAnnotations;

namespace PropertyManagement.BLL.Dtos.User
{
    public class UserCreateDto
    {
        [Required]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
