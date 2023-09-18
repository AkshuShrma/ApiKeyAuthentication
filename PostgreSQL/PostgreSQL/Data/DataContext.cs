using Microsoft.EntityFrameworkCore;
using PostgreSQL.Models;

namespace PostgreSQL.Data
{
    public class DataContext:DbContext
    {
        protected readonly IConfiguration _configuration;
        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Student> Students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("PostgreSQL"));
        }
    }
}
