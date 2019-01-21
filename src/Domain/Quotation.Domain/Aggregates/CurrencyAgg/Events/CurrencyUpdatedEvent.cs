using Quotation.Domain.Seedwork;

namespace Quotation.Domain.Aggregates.CurrencyAgg.Events {
    public class CurrencyUpdatedEvent : Event<Currency> {
        public CurrencyUpdatedEvent(Currency currency) : base("currency.updated", currency) {
        }
    }
}


