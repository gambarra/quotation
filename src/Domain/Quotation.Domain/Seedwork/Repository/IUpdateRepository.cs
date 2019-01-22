namespace Quotation.Domain.Seedwork.Repository {
    public interface IUpdateRepository<TEntity> where TEntity : class {
        void Update(TEntity entity);
    }
}
