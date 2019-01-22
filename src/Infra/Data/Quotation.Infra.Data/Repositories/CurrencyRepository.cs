using Microsoft.EntityFrameworkCore;
using Quotation.Domain.Aggregates.CurrencyAgg;
using Quotation.Domain.Aggregates.CurrencyAgg.Repository;
using Quotation.Domain.Seedwork;
using Quotation.Infra.Data.Seedwork;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Quotation.Infra.Data.Repositories {
    public class CurrencyRepository : BaseRepository<Currency>, ICurrencyRepository {

        public CurrencyRepository(Context context, IUnitOfWork unitOfWork) : base(context, unitOfWork) {
        }

        public Task Add(Currency entity) {
            return DbSet.AddAsync(entity);
        }

        public Task<Currency> FindOneAsync(Expression<Func<Currency, bool>> filter) {
            IQueryable<Currency> set = DbSet;
            return set.FirstOrDefaultAsync(filter);
        }

        public void Update(Currency entity) {
            DbSet.Update(entity);
        }
    }
}
