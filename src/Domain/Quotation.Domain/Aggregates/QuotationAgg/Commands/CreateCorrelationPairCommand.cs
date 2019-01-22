using Quotation.Domain.Seedwork;
using System;

namespace Quotation.Domain.Aggregates.QuotationAgg.Commands {
    public class CreateCorrelationPairCommand : ICommand<CommandResult<CorrelationPair>> {

        public CreateCorrelationPairCommand() {
            this.QuotationDate = DateTime.Now;
        }
        public int BaseCurrencyId { get; set; }
        public int QuoteCurrencyId { get; set; }
        public decimal Coefficient { get; set; }
        public DateTime QuotationDate { get; set; }

    
    }
}
