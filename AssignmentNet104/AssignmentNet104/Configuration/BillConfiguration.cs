using _1.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Assignment.Configurations
{
    public class BillConfiguration : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.HasKey(p => p.IdBill);
            builder.Property(p => p.Status).HasColumnType("int").IsRequired();
            builder.HasOne(p => p.Customer).WithMany(x => x.Bills).HasForeignKey(x => x.IdCustomer).HasConstraintName("FK_KH");
            builder.HasOne(p => p.Staff).WithMany(x => x.Bills).HasForeignKey(x => x.IdStaff).HasConstraintName("FK_NV");

        }
    }
}
