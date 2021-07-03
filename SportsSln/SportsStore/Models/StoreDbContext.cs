using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace SportsStore.Models
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
    }
}