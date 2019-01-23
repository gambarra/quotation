using Quotation.Domain.Aggregates.QuotationAgg.Events;
using Quotation.Domain.Seedwork;
using System;

namespace Quotation.Domain.Aggregates.QuotationAgg {
    public class CorrelationPair:Entity {

        private CorrelationPair() {

        }
        public CorrelationPair(int baseCurrencyId, int quoteCurrencyId, decimal coeficient,DateTime quotationDate) :base() {
            this.CreatedAt = DateTime.Now;
            this.BaseCurrencyId = baseCurrencyId;
            this.QuoteCurrencyId = quoteCurrencyId;
            this.Coefficient = coeficient;
            this.QuotationDate = quotationDate;
            this.RaiseEvent(new CorrelationPairCreatedEvent(this));
        }

        public int BaseCurrencyId { get; private set; }
        public int QuoteCurrencyId { get; private set; }
        public decimal Coefficient { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime QuotationDate { get; private set; }
        public DateTime? DeleatedAt { get; private set; }
    }
}
