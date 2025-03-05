using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public class RegisterModel
    {

        public string? UserId { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]

        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password Not Matche")]
        public string ConfirmPassword { get; set; }


    }
}
