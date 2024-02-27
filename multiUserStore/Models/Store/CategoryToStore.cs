using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using multiUserStore.Models.Categories;

namespace multiUserStore.Models.Store
{
    public class CategoryToStore
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }

        public StoreModel store { get; set; }
        public int StoreId { get; set; }

    }
}
