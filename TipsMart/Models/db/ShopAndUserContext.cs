using Microsoft.EntityFrameworkCore;

namespace TipsMart.Models.db
{
    public partial class ShopAndUserContext : DbContext
    {
        public virtual DbSet<Shops> Shops { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Purchase> Purchase { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               optionsBuilder.UseSqlServer(@"Server=DESKTOP-NNBNQ4H;Database=ShopAndUser;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Shops>(entity =>
            {
                entity.HasKey(e => e.ShopId);

                entity.Property(e => e.ShopId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Balance).HasColumnType("money");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.Property(e => e.UserId);

                entity.Property(e => e.ShopId);

                entity.Property(e => e.PurchaseAmount).HasColumnType("money");
            });
        }
    }
}
