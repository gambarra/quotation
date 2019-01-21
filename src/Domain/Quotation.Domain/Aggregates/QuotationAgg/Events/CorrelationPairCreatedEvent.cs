using Quotation.Domain.Seedwork;

namespace Quotation.Domain.Aggregates.QuotationAgg.Events {
    public class CorrelationPairCreatedEvent : Event<CorrelationPair> {
        public CorrelationPairCreatedEvent( CorrelationPair eventData) : base("correlationpair.created", eventData) {
        }
    }
}
