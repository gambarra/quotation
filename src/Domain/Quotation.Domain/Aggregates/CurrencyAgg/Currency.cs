using Quotation.Domain.Aggregates.CurrencyAgg.Events;
using Quotation.Domain.Seedwork;
using System;

namespace Quotation.Domain.Aggregates.CurrencyAgg {
    public class Currency : Entity {

        public Currency(string name, string isoCode):base() {
            this.Name = name;
            this.IsoCode = isoCode;
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = this.CreatedAt;
            RaiseEvent(new CurrencyCreatedEvent(this));
        }
        
        public string Name { get; private set; }
        public string IsoCode { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        internal void Update(string name) {
            this.Name = name;
            this.UpdatedAt = DateTime.Now;
            RaiseEvent(new CurrencyUpdatedEvent(this));
        }
    }
}
