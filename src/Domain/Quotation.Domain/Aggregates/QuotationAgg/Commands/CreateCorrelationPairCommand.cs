using Quotation.Domain.Seedwork;
using System;

namespace Quotation.Domain.Aggregates.QuotationAgg.Commands {
    public class CreateCorrelationPairCommand : ICommand<CorrelationPair> {

        public Guid BaseCurrencyId { get; set; }
        public Guid QuoteCurrencyId { get; set; }
        public decimal Coefficient { get; set; }

        public bool IsValid() {
            throw new NotImplementedException();
        }
    }
}
