using System.Threading.Tasks;

namespace Quotation.Domain.Seedwork.Repository {
    public interface IUpdateRepository<TEntity> where TEntity : class {
        Task Update(TEntity entity);
    }
}
