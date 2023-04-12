using _1.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Assignment.Configurations
{
    public class BillDetailConfiguration : IEntityTypeConfiguration<BillDetail>
    {
        public void Configure(EntityTypeBuilder<BillDetail> builder)
        {
            builder.HasKey(x => x.IdMDetail);
            builder.Property(x => x.Amount).HasColumnType("int").IsRequired();
            builder.Property(x => x.Price).HasColumnType("decimal").IsRequired();
            builder.HasOne(x => x.Material).WithMany(x => x.BillDetails).HasForeignKey(x => x.IdMaterial).HasConstraintName("FK_SP");
            builder.HasOne(x => x.Bill).WithMany(x => x.BillDetails).HasForeignKey(x => x.IdBill).HasConstraintName("FK_HD");
        }
    }
}
