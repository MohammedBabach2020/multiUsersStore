using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using multiUserStore.Validators;

namespace multiUserStore.Models.Orders
{
    public class OrderDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int order_id; 
        public Order order { get; set; }



        [Required]
        public required string prod_name { get; set; }  
        
        [Required]
        public required float prod_price{ get; set; }


        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "The minimum value need to be one")]
        public float Quantity { get; set; }


        [Required]

        [AmmountValidator(nameof(prod_price), ErrorMessage = "The amount should be equal to the product of Quantity and prod_price.")]
        public float amount  { get; set; }
    }
}
