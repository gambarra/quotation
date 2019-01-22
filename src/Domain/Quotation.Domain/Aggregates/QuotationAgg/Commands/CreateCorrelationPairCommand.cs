using Quotation.Domain.Seedwork;
using System;

namespace Quotation.Domain.Aggregates.QuotationAgg.Commands {
    public class CreateCorrelationPairCommand : ICommand<CommandResult<CorrelationPair>> {

        public int BaseCurrencyId { get; set; }
        public int QuoteCurrencyId { get; set; }
        public decimal Coefficient { get; set; }

        public bool IsValid() {
            throw new NotImplementedException();
        }
    }
}
