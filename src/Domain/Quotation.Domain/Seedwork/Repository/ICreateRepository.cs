using System.Threading.Tasks;

namespace Quotation.Domain.Seedwork.Repository {
    public interface ICreateRepository<TEntity> where TEntity : class {
        Task Add(TEntity entity);
    }
}
