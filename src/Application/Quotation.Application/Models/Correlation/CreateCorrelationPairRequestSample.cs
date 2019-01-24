using Bogus;
using Swashbuckle.AspNetCore.Examples;
using System;

namespace Quotation.Application.Models.Correlation {
    public class CreateCorrelationPairRequestSample : IExamplesProvider {
        public object GetExamples() {
            return new Faker<CreateCorrelationPairRequest>()
               .RuleFor(p => p.BaseCurrencyIso, "USD")
               .RuleFor(p => p.QuoteCurrencyIso, "BRL")
               .RuleFor(p=>p.Coefficient,4)
               .RuleFor(p=>p.QuotationDate,DateTime.Now);
        }
    }
}
