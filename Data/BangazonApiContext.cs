using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BangazonAPI.Models;

namespace BangazonAPI.Data 
{
    public class BangazonAPIContext : DbContext
    {
         public BangazonAPIContext(DbContextOptions<BangazonAPIContext> options)
            : base(options)
        { }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderProduct> OrderProduct { get; set; }
        public DbSet<PaymentType> PaymentType { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<TrainingEmployee> TrainingEmployee { get; set; }
        public DbSet<TrainingProgram> TrainingProgram { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
} 
