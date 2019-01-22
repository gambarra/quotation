using System.Collections.Generic;

namespace Quotation.Domain.Seedwork {
    public abstract class CommandHandler<TEntity> where TEntity : Entity {

        public CommandHandler(IEventBus eventBus) {
            this.eventBus = eventBus;
        }
        private readonly IEventBus eventBus;

        protected void PublishEvents(TEntity entity) {
            eventBus.AddEvents(entity.Events);
        }
    }
}
