using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using multiUserStore.Validators;
using multiUserStore.Models.Account;

namespace multiUserStore.Models.Cart
{
    public class CartItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string imagepPath { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public float Quantity  { get; set; }

        [Required]
        public float price { get; set; }


        [Required]
        [AmmountValidator(nameof(price), ErrorMessage = "The amount should be equal to the product of Quantity and prod_price.")]
        public float amount { get; set; }




        [Required]
        public int client_id { get; set; }
    }
}
