using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quotation.Domain.Aggregates.CurrencyAgg;

namespace Quotation.Infra.Data.Mapping {
    public class CurrencyMap : IEntityTypeConfiguration<Currency> {

        public void Configure(EntityTypeBuilder<Currency> builder) {

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Key).IsRequired();
            builder.Property(p => p.IsoCode).IsRequired().HasMaxLength(3);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(15);
            builder.Property(p => p.UpdatedAt).IsRequired();
            builder.Property(p => p.CreatedAt).IsRequired();
            builder.Ignore(p => p.Events);
        }
    }
}
