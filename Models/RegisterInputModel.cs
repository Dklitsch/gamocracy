using System.ComponentModel.DataAnnotations;

namespace gamocracy.Models
{
    public class RegisterInputModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [RegularExpression(@"^.*(?=.*[a-zA-Z])(?=.*\d)(?=.*[!#$%&? ""]).*$", ErrorMessage="The {0} requires at least one lower case letter, one upper case letter, a number and a symbol.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
