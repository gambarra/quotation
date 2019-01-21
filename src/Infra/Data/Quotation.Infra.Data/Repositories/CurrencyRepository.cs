using Quotation.Domain.Aggregates.CurrencyAgg;
using Quotation.Domain.Aggregates.CurrencyAgg.Repository;
using Quotation.Domain.Seedwork;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Quotation.Infra.Data.Repositories {
    public class CurrencyRepository : ICurrencyRepository {

        public CurrencyRepository(IUnitOfWork unitOfWork) {
            this.unitOfWork = unitOfWork;
        }

        private readonly IUnitOfWork unitOfWork;

        public Task Add(Currency entity) {
            throw new NotImplementedException();
        }

        public Task<Currency> FindOneAsync(Expression<Func<Currency, bool>> filter) {
            throw new NotImplementedException();
        }

        public Task Update(Currency entity) {
            throw new NotImplementedException();
        }
    }
}
