using Microsoft.EntityFrameworkCore;
using Quotation.Domain.Seedwork;
using Quotation.Infra.Data.Seedwork;

namespace Quotation.Infra.Data.Repositories {
    public abstract class BaseRepository<T> where T:Entity {

        protected readonly Context context;
        protected readonly IUnitOfWork unitOfWork;
        protected readonly DbSet<T> DbSet;

        public BaseRepository(Context context, IUnitOfWork unitOfWork) {
            this.context = context;
            this.unitOfWork = unitOfWork;
            this.DbSet = context.Set<T>();

        }
    }
}
