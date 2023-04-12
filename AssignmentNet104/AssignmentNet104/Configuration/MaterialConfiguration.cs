using _1.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Assignment.Configurations
{
    public class MaterialConfiguration : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
            builder.HasKey(x => x.IdMaterial);
            builder.Property(x => x.Status).HasColumnType("int").IsRequired();
            builder.Property(x => x.Name).HasColumnType("nvarchar(100)");
            builder.Property(x => x.Code).HasColumnType("nvarchar(10)").IsRequired();
        }
    }
}
