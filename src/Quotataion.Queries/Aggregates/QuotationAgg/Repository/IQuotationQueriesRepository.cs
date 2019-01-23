using Quotation.Helper;
using Quotation.Queries.Aggregates.QuotationAgg.Models;
using System.Collections.Generic;

namespace Quotation.Queries.Aggregates.QuotationAgg.Repository {
    public interface IQuotationQueriesRepository {
        IList<QuotationModel> Find(Specification<QuotationModel> specification);
    }
}
