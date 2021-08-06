using Microsoft.EntityFrameworkCore;
using SupplierApp.Concrete.Entities;

namespace SupplierApp.Concrete.EF.Contexts
{
    public class AppDbContext : DbContext
    {
        /* Tables */
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Server=.; Database=SupplierApp; uid=sa; pwd=123456; MultipleActiveResultSets=true");
                optionsBuilder.UseSqlServer("Server=.; Database=SupplierApp; Trusted_Connection=true; MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         
            modelBuilder.Entity<Product>().Property(p => p.PriceIncludedTax).HasComputedColumnSql("[UnitPrice] + ([UnitPrice] * ([Tax] / 100))").HasPrecision(18, 2);
        }
    }
}
