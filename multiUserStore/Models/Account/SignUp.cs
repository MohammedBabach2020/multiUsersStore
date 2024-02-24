using System.ComponentModel.DataAnnotations;


namespace multiUserStore.Models.Account
{
    public class SignUp
    {
        [Required]
        [MaxLength(30)]
        public required string Name { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }
        [Required]
        [Compare("Email", ErrorMessage = "The email and confirmation email do not match.")]
        public required string ConfirmEMail { get; set; }

        [Required]
        [MinLength(8)]
        public required string Password { get; set; }


        [Required]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public required string ConfirmPassword { get; set; }

      
    }
}
