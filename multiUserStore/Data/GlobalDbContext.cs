using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using multiUserStore.Models.Account;
using multiUserStore.Models.Categories;
using multiUserStore.Models.Store;



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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<StoreModel>()
        
              .HasOne(s => s.owner)
              .WithMany(c => c.Stores)
              .HasForeignKey(s => s.OwnerId)
              .IsRequired();

            modelBuilder.Entity<StoreModel>()
               .HasMany(c => c.Categories);

        }


    }
}
