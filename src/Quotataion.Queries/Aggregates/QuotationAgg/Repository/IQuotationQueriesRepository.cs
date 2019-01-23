using Quotation.Queries.Aggregates.QuotationAgg.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Quotation.Queries.Aggregates.QuotationAgg.Repository {
    public interface IQuotationQueriesRepository {
        IList<QuotationModel> Find(Expression<Func<QuotationModel, bool>> expression);
    }
}
