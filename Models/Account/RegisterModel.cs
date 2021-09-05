using System.ComponentModel.DataAnnotations;

namespace Models.Account
{
    public class RegisterModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{4,}$", ErrorMessage = "Password must contain at least 4 and 8 characters, at least one lower case letter, one upper case letter and one number.")]
        public string Password { get; set; }

        [Required]
        public string DisplayName { get; set; }        
    }
}
