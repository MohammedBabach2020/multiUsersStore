using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace multiUserStore.Models.Orders
{
    public class OrderDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }



        [Required]
        public string prod_name { get; set; }  
        
        [Required]
        public string prod_price{ get; set; }
    }
}
