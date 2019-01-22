using System;
using System.Collections.Generic;

namespace Quotation.Domain.Seedwork {
    public abstract class Entity {

        protected Entity() {
         
            this.events = new List<IEvent>();
            this.Key = Guid.NewGuid();
        }
        private readonly List<IEvent> events;

        public int Id { get; private set; }
        public Guid Key { get; private set; }


        public IReadOnlyCollection<IEvent> Events => events;

        protected void RaiseEvent(IEvent @event) {
            events.Add(@event);
        }

        public void ClearEvents() {
            events.Clear();
        }

    }
}
