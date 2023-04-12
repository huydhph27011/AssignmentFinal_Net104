using _1.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Assignment.Configurations
{
    public class StaffConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.HasKey(x => x.IdStaff);
            builder.Property(x => x.Code).HasColumnType("nvarchar(10)").IsRequired();
            builder.HasOne(x => x.Store).WithMany(x => x.Staffs).HasForeignKey(x => x.IdStore).HasConstraintName("FK_CH");
            builder.HasOne(x => x.Position).WithMany(x => x.Staffs).HasForeignKey(x => x.IdPosition).HasConstraintName("FK_CV");
        }
    }
}
