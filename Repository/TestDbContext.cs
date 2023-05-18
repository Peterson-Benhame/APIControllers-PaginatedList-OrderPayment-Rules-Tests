using Bogus;
using Microsoft.EntityFrameworkCore;
using ProvaPub.Models;

namespace ProvaPub.Repository
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().HasData(getCustomerSeed());
            modelBuilder.Entity<Product>().HasData(getProductSeed());

            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<Order>().HasKey(o => o.Id);
            modelBuilder.Entity<Order>().Property(o => o.Value).IsRequired();
            modelBuilder.Entity<Order>().Property(o => o.CustomerId);            
            modelBuilder.Entity<Order>().Property(o => o.MetodyPayment);
            modelBuilder.Entity<Order>().Property(o => o.OrderDate);
            modelBuilder.Entity<Order>().HasOne(o => o.Customer).WithMany(c => c.Orders).HasForeignKey(o => o.CustomerId);       
        }


        private Customer[] getCustomerSeed()
        {
            List<Customer> result = new();
            for (int i = 0; i < 20; i++)
            {
                result.Add(new Customer()
                {
                    Id = i + 1,
                    Name = new Faker().Person.FullName,
                });
            }
            return result.ToArray();
        }
        private Product[] getProductSeed()
        {
            List<Product> result = new();
            for (int i = 0; i < 20; i++)
            {
                result.Add(new Product()
                {
                    Id = i + 1,
                    Name = new Faker().Commerce.ProductName()
                });
            }
            return result.ToArray();
        }
    }
}
