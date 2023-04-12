using _1.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Assignment.Configurations
{
    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.HasKey(x => x.IdStore);
            builder.Property(x => x.Status).HasColumnType("int").IsRequired();
            builder.Property(x => x.Name).HasColumnType("nvarchar(100)");
            builder.Property(x => x.Code).HasColumnType("nvarchar(10)").IsRequired();
        }
    }
}
