using multiUserStore.Models.Categories;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using multiUserStore.Models.Account;

namespace multiUserStore.Models.Store
{
    public class StoreModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required]
        public int OwnerId { get; set; }
        [Required]
        public required User owner { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Description { get; set; }

        [Required]
        public List<Category> Categories { get; set; } = [];

        [Required]
        public required DateTime CreatedDate { get; set; }

    }
}
