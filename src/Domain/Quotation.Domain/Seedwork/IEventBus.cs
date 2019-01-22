using System.Collections.Generic;

namespace Quotation.Domain.Seedwork {

    public interface IEventBus {
        void AddEvent(IEvent @event);
        void AddEvents(IReadOnlyCollection<IEvent> events);
    }
}
