using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Quotation.Domain.Seedwork.Repository {
    public interface IQueryRepository<TEntity> where TEntity : class {

        Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>> filter);
    }
}
