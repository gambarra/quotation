using MediatR;
using Quotation.Domain.Seedwork;
using System;

namespace Quotation.Domain.Aggregates.CurrencyAgg.Commands {
    public sealed class CreateCurrencyCommand: ICommand<CommandResult<Currency>> {

        public string Name { get; set; }
        public string CurrencyIso { get; set; }

    }
}
