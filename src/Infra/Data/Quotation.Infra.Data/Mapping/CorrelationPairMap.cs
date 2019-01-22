using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quotation.Domain.Aggregates.QuotationAgg;

namespace Quotation.Infra.Data.Mapping {
    public class CorrelationPairMap : IEntityTypeConfiguration<CorrelationPair> {

        public void Configure(EntityTypeBuilder<CorrelationPair> builder) {

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Key);
            builder.Property(p => p.DeleatedAt);
            builder.Property(p => p.CreatedAt).IsRequired();
            builder.Property(p => p.Coefficient).IsRequired();
            builder.Property(p => p.QuoteCurrencyId).IsRequired();
            builder.Property(p => p.BaseCurrencyId).IsRequired();

        }
    }
}
