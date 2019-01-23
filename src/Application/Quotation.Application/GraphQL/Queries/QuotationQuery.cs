using GraphQL.Types;
using Quotation.Application.GraphQL.Types;
using Quotation.Queries.Aggregates.QuotationAgg.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quotation.Application.GraphQL.Queries {
    public class QuotationQuery : ObjectGraphType {

        private readonly IQuotationQueriesRepository quotationQueriesRepository;

        public QuotationQuery(IQuotationQueriesRepository quotationQueriesRepository) {

            this.quotationQueriesRepository = quotationQueriesRepository;

            Field<ListGraphType<QuotationType>>(
                "quotations",
                resolve: Resolve);
        }

        protected object Resolve(ResolveFieldContext<object> context) {

            var entender = context.FieldAst;

            return quotationQueriesRepository.Find(p => p.BaseCurrencyIso == "USD");
        }
    }
}
