using System.Collections.Generic;

namespace Quotation.Domain.Seedwork {
    public abstract class CommandHandler<TEntity> where TEntity : Entity {

        public CommandHandler(IUnitOfWork unitOfWork) {
            this.unitOfWork = unitOfWork;
        }
        private readonly IUnitOfWork unitOfWork;

        protected void PublishEvents(TEntity entity) {
            unitOfWork.AddEvents(entity.Events);
        }
    }
}
