using Quotation.Domain.Seedwork;
using System;

namespace Quotation.Domain.Aggregates.QuotationAgg {
    public class CorrelationPair:Entity {


        public CorrelationPair(Guid baseCurrencyId, Guid quoteCurrencyId, decimal coeficient) :base() {
            this.CreatedAt = DateTime.Now;
            this.BaseCurrencyId = baseCurrencyId;
            this.QuoteCurrencyId = quoteCurrencyId;
            this.Coefficient = coeficient;
        }

        public Guid BaseCurrencyId { get; private set; }
        public Guid QuoteCurrencyId { get; private set; }
        public decimal Coefficient { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? DeleatedAt { get; set; }
    }
}
