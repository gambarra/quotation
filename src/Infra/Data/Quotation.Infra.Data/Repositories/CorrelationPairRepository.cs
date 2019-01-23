using Microsoft.EntityFrameworkCore;
using Quotation.Domain.Aggregates.QuotationAgg;
using Quotation.Domain.Aggregates.QuotationAgg.Repository;
using Quotation.Domain.Seedwork;
using Quotation.Infra.Data.Seedwork;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Quotation.Infra.Data.Repositories {
    public class CorrelationPairRepository : BaseRepository<CorrelationPair>, ICorrelationPairRepository {

        public CorrelationPairRepository(Context context, IUnitOfWork unitOfWork) : base(context, unitOfWork) {
        }

        public Task Add(CorrelationPair entity) {
            return DbSet.AddAsync(entity);
        }

        public Task<CorrelationPair> FindOneAsync(Expression<Func<CorrelationPair, bool>> filter) {
            IQueryable<CorrelationPair> set = DbSet;
            return set.FirstOrDefaultAsync(filter);
        }
    }
}
