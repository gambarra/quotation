using Quotation.Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Quotation.Infra.EventBus {
    public class MockEventBus : IEventBus {
        public void AddEvent(IEvent @event) {
            Console.WriteLine(@event.GetEventType());

        }

        public void AddEvents(IReadOnlyCollection<IEvent> events) {
            events.ToList().ForEach(p => this.AddEvent(p));
        }
    }
}
