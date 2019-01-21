using Quotation.Domain.Seedwork.Repository;

namespace Quotation.Domain.Aggregates.QuotationAgg.Repository {
    public interface ICorrelationPairRepository : 
        ICreateRepository<CorrelationPair>,
        IQueryRepository<CorrelationPair> {
    }
}
