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

        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<TrainingEmployee> TrainingEmployee { get; set; }
        public DbSet<TrainingProgram> TrainingProgram { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
} 
