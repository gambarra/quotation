using MediatR;

namespace Quotation.Domain.Seedwork {
    public abstract class Event<T>: INotification {

        public Event(string eventType, T eventData) {
            this.EventType = eventType;
            this.EventData = eventData;
        }
        public string EventType { get; private set; }
        public T EventData { get; private set; }
    }
}
