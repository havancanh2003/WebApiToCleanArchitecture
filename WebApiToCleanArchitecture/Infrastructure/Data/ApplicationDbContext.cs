using Microsoft.EntityFrameworkCore;
using WebApiToCleanArchitecture.Domain.Entities;

namespace WebApiToCleanArchitecture.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }

    }
}
