using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings
{
    class BuilderMap: IEntityTypeConfiguration<Builder>
    {
        public void Configure(EntityTypeBuilder<Builder> builder)
        {
            builder.ToTable("Builder");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(80);

            builder.Property(x => x.About)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(x => x.Cnpj)
                .IsRequired()
                .HasMaxLength(14);

            builder.Property(x => x.Segment)
                .IsRequired()
                .HasMaxLength(80);

            builder.Property(x => x.FoundationDate)
                .IsRequired();
        }
    }
}
