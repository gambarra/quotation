using Quotation.Domain.Seedwork.Repository;

namespace Quotation.Domain.Aggregates.CurrencyAgg.Repository {
    public interface ICurrencyRepository : 
        ICreateRepository<Currency>,
        IUpdateRepository<Currency>, 
        IQueryRepository<Currency> {
    }
}
