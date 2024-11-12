using Microsoft.EntityFrameworkCore;

namespace EF_Relations.Data
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<CustomerAddresses> CustomerAddresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerAddresses>()
                .HasOne(_ => _.Customer)
                .WithMany(_ => _.customerAddresses)
                .HasForeignKey(_ => _.CustomerId);
        }
    }
}
