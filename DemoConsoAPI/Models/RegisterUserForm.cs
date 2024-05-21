using System.ComponentModel.DataAnnotations;

namespace DemoConsoAPI.Models
{
    public class RegisterUserForm
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Nickname { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }


    }
}
