using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using multiUserStore.Models.Account;
using multiUserStore.Models.Categories;
using multiUserStore.Models.Store;
using multiUserStore.Models.Product;
using multiUserStore.Models.Orders;
using multiUserStore.Models.Cart;



namespace multiUserStore.Data
{
    public class GlobalDbContext : DbContext
    {

        public GlobalDbContext(DbContextOptions<GlobalDbContext> options) : base(options)
        {
        }

      
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<StoreModel> Store { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<CategoryToStore> CategoryToStore { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        

            modelBuilder.Entity<StoreModel>(entity =>

            { 
                //-------------------each user has one store
                entity.HasOne(u => u.Owner)
               .WithOne(s => s.Store)
               .HasForeignKey<User>(u => u.StoreId)
               .OnDelete(DeleteBehavior.Cascade);
                //-------------------each store has many related products
                entity.HasMany(c => c.Products)
                 .WithOne(s => s.Store)
                 .HasForeignKey(s => s.StoreId);

            }) ;


            //------------------- many categories to many stores
            modelBuilder.Entity<CategoryToStore>(entity => {
            entity.HasKey(cts => new {cts.StoreId , cts.CategoryId});
                entity.HasOne(s => s.store)
                    .WithMany(c => c.Categories)
                    .HasForeignKey(cid => cid.StoreId)
                    .OnDelete(DeleteBehavior.NoAction);
            });



            //------------------- each user can make many orders 
            modelBuilder.Entity<User>(entity => {

                entity.HasMany<Order>(s => s.Order)
                .WithOne(u => u.client)
                .HasForeignKey(u=> u.client_id)
                .OnDelete(DeleteBehavior.ClientCascade);
            
            });

            //------------------- each order can have many details 

            modelBuilder.Entity<Order>(entity => {
                entity.HasMany<OrderDetails>(od=>od.Details)
                .WithOne(o => o.order)
                .HasForeignKey(o => o.order_id)
                .OnDelete(DeleteBehavior.ClientCascade);
            });


        




        }
        public DbSet<multiUserStore.Models.Cart.CartItem> CartItem { get; set; } = default!;


    }
}
