using System.Collections.Generic;

namespace Quotation.Domain.Seedwork {

    public interface IEventBus {
        void AddEvent<T>(Event<T> @event);
        void AddEvents<T>(IReadOnlyCollection<Event<T>> events);
    }
}
