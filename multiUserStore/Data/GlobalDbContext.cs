using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using multiUserStore.Models.Account;
using multiUserStore.Models.Categories;
using multiUserStore.Models.Store;
using multiUserStore.Models.Product;



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
        public DbSet<CategoryToStore> CategoryToStore { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<StoreModel>(entity =>

            {
                entity.HasOne(u => u.Owner)
               .WithOne(s => s.Store)
               .HasForeignKey<User>(u => u.StoreId)
               .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(c => c.Products)
                 .WithOne(s => s.Store)
                 .HasForeignKey(s => s.StoreId);

            }) ;



            modelBuilder.Entity<CategoryToStore>(entity => {
            
            
            
            entity.HasKey(cts => new {cts.StoreId , cts.CategoryId});
                entity.HasOne(s => s.store)
                    .WithMany(c => c.Categories)
                    .HasForeignKey(cid => cid.StoreId)
                    .OnDelete(DeleteBehavior.NoAction);
            });



        }


    }
}
