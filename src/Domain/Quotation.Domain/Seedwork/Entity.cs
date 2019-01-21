using MediatR;
using Quotation.Infra.Mapper;
using System;
using System.Collections.Generic;

namespace Quotation.Domain.Seedwork {
    public abstract class Entity {

        public Entity() {
         
            this.events = new List<INotification>();
        }
        private readonly List<INotification> events;

        public int Id { get; private set; }


        public IReadOnlyCollection<INotification> Events => events;

        protected void RaiseEvent(INotification @event) {
            events.Add(@event);
        }

        public void ClearEvents() {
            events.Clear();
        }

    }
}
