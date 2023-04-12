using _1.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Assignment.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.IdCustomer);
            builder.Property(x => x.Code).HasColumnType("nvarchar(10)").IsRequired();
            builder.Property(x => x.Name).HasColumnType("nvarchar(100)");
            builder.Property(x => x.Address).HasColumnType("nvarchar(100)");
        }
    }
}
