using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using multiUserStore.Models.Store;

namespace multiUserStore.Models.Categories
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required]
        public required string name { get; set; }
        [Required]
        public required DateTime CreatedDate { get; set; }

        public ICollection<CategoryToStore> Stores { get; set; }
    }
}
