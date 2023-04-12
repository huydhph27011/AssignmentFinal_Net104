using _1.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Assignment.Configurations
{
    public class ProducerConfiguration : IEntityTypeConfiguration<Producer>
    {
        public void Configure(EntityTypeBuilder<Producer> builder)
        {
            builder.HasKey(x => x.IdProducer);
            builder.Property(x => x.Code).HasColumnType("nvarchar(10)").IsRequired();
        }
    }
}
