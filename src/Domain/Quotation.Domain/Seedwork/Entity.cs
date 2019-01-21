using MediatR;
using Quotation.Infra.Mapper;
using System;
using System.Collections.Generic;

namespace Quotation.Domain.Seedwork {
    public abstract class Entity {

        public Entity() {
         
            this.events = new List<INotification>();
            this.Key = Guid.NewGuid();
        }
        private readonly List<INotification> events;

        public int Id { get; private set; }
        public Guid Key { get; private set; }


        public IReadOnlyCollection<INotification> Events => events;

        protected void RaiseEvent(INotification @event) {
            events.Add(@event);
        }

        public void ClearEvents() {
            events.Clear();
        }

    }
}
