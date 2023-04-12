using _1.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Assignment.Configurations
{
    public class MaterialDetailConfiguration : IEntityTypeConfiguration<MaterialDetail>
    {
        public void Configure(EntityTypeBuilder<MaterialDetail> builder)
        {
            builder.HasKey(c => c.IdMDetail);
            builder.Property(c => c.Amount).HasColumnType("int").IsRequired();
            builder.Property(c => c.Unit).HasColumnType("nvarchar(100)");
            builder.HasOne(x => x.Producer).WithMany(x => x.MaterialDetails).HasForeignKey(x => x.IdProducer).HasConstraintName("FK_Nsx");
            builder.HasOne(x => x.Material).WithMany(x => x.MaterialDetails).HasForeignKey(x => x.IdMaterial).HasConstraintName("FK_SP2");
        }
    }
}
