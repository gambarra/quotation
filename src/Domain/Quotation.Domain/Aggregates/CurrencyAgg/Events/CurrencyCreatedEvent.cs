using Quotation.Domain.Seedwork;

namespace Quotation.Domain.Aggregates.CurrencyAgg.Events {
    public class CurrencyCreatedEvent : Event<Currency> {

        public CurrencyCreatedEvent( Currency eventData) : base("currency.created", eventData) {
        }
    }
}
