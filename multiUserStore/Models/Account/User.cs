using Microsoft.EntityFrameworkCore;
using multiUserStore.Models.Store;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace multiUserStore.Models.Account
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public required string Name { get; set; }

        [Required]
        [EmailAddress]

        public required string Email { get; set; }

        [Required]
        [MinLength(8)]
        public required string Password { get; set; }

        [Required]
        public required StoreModel Store { get; set; }


        [Required]
        public required int StoreId { get; set; }
        [Required]
        public required DateTime CreatedDate { get; set; }
    }
}
