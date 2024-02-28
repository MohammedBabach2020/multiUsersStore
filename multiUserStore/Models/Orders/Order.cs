using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using multiUserStore.Models.Account;
using multiUserStore.Models.Store;

namespace multiUserStore.Models.Orders
{
    public class Order
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }



        [Required]
        public required float total_amount { get; set; }

        [Required]
        public string shippingAddress { get; set; }


        [Required]
        public string phoneNumber { get; set; }

        [Required]
        public string city { get; set; }
        [Required]
        public string state { get; set; }

        [Required]
        public required DateTime CreatedDate { get; set; }
        public ICollection<OrderDetails> Details { get; set; }

        public StoreModel store { get; set; }
        public int store_id    { get; set; }


        [Required]
        public User client { get; set; }
        [Required]
        public int client_id { get; set; }



    }
}
