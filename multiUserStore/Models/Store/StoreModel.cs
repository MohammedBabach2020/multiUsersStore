using multiUserStore.Models.Categories;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using multiUserStore.Models.Account;
using multiUserStore.Models.Product;

namespace multiUserStore.Models.Store
{
    public class StoreModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }




        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Description { get; set; }

     
    


        [Required]
        public required User Owner { get; set; }



        [Required]
        public int OwnerId { get; set; }


        [Required]
        public required DateTime CreatedDate { get; set; }

    

      
        public  ICollection<Products> Products { get; set; }
        public ICollection<CategoryToStore> Categories { get; set; }

    }
}
