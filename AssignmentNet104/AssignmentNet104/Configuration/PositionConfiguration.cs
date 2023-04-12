using _1.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Assignment.Configurations
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.HasKey(x => x.IdPosition);
            builder.Property(x => x.Status).HasColumnType("int").IsRequired();
            builder.Property(x => x.Name).HasColumnType("nvarchar(100)");
            builder.Property(x => x.Code).HasColumnType("nvarchar(10)").IsRequired();
        }
    }
}
