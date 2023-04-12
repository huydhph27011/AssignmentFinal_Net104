using _1.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Assignment.Models
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext()
        {

        }

        public ShopDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Account> accounts { get; set; }
        public DbSet<Bill> bills { get; set; }
        public DbSet<BillDetail> billDetailss { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<MaterialDetail> MaterialDetails { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Store> Stores { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=HHH\SQLEXPRESS;Initial Catalog=AssignmentNet104;User ID=huydhph27011;Password=666888");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
