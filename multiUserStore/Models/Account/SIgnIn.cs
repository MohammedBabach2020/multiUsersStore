using System.ComponentModel.DataAnnotations;

namespace multiUserStore.Models.Account
{
    public class SIgnIn
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [MinLength(8)]
        public required string Password { get; set; }
    }
}
