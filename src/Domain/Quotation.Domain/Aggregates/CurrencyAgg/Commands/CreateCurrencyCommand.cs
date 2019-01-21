using Quotation.Domain.Seedwork;
using System;

namespace Quotation.Domain.Aggregates.CurrencyAgg.Commands {
    public sealed class CreateCurrencyCommand:ICommand<Currency> {

        public string Name { get; set; }
        public string CurrencyIso { get; set; }

        public bool IsValid() {
            throw new NotImplementedException();
        }
    }
}
