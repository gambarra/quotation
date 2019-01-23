using GraphQL.Types;
using Quotation.Queries.Aggregates.QuotationAgg.Models;

namespace Quotation.Application.GraphQL.Types {
    public class QuotationType : ObjectGraphType<QuotationModel> {
        public QuotationType() {
            Name = "Quotation";
            Field(p => p.BaseCurrencyIso).Description("Base quotation currency code.");
            Field(p => p.QuoteCurrencyIso).Description("Quoted currency code.");
            Field(p => p.QuotationDate).Description("Quotation date.");
            Field(p => p.Quotation).Description("Quotation");
        }
    }
}
