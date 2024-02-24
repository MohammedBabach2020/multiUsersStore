using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace multiUserStore.Models.Product
{
    public class Products
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public required int StoreId;


        [Required]
        public  required string Name { get; set; }

        [Required]
        public required string Description { get; set; }

        [Required]
        public required string ImageUrl { get; set; }

        [Required]
        public required float byuing_price {  get; set; }

        [Required]
        public required float selling_price { get; set; }

        [Required]
        public required bool has_promotion { get; set; }

        [Required]
        public required float ammount_promotion { get; set; }

        [Required]
        public required DateTime CreatedDate { get; set; }
    }

}
