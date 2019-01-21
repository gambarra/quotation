using Quotation.Domain.Seedwork;
using System;

namespace Quotation.Domain.Aggregates.CurrencyAgg.Commands {
    public sealed class CreateCurrencyCommand:Command<CommandResult<Currency>> {

        public string Name { get; set; }
        public string CurrencyIso { get; set; }

    }
}
