using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings
{
    class EnterpriseMap: IEntityTypeConfiguration<Enterprise>
    {
        public void Configure(EntityTypeBuilder<Enterprise> builder)
        {
            builder.ToTable("Enterprise");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(80);

            builder.Property(x => x.Value)
                .IsRequired();

            builder.Property(x => x.IdBuilder)
                .IsRequired();

            builder.Property(x => x.ProfitabilityPerYear)
                .IsRequired();

            builder.Property(x => x.TermInMonths)
                .IsRequired();

            builder.Property(x => x.PaymentType)
                .IsRequired();
        }
    }
}
