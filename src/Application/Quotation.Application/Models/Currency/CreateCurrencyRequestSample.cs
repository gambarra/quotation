using Bogus;
using Swashbuckle.AspNetCore.Examples;

namespace Quotation.Application.Models.Currency {
    public class CreateCurrencyRequestSample : IExamplesProvider {
        public object GetExamples() {

            return new Faker<CreateCurrencyRequest>()
                .RuleFor(p => p.CurrencyIso, "USD")
                .RuleFor(p => p.Name, "Dollar");
        }
    }
}
