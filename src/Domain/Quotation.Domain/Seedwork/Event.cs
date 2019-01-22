using MediatR;
using System;

namespace Quotation.Domain.Seedwork {
    public abstract class Event<T> : IEvent {

        public Event(string eventType, T eventData) {
            this.EventType = eventType;
            this.EventData = eventData;
            this.CreatedAt = DateTime.Now;
        }

        public DateTime CreatedAt { get; set; }
        public string EventType { get; private set; }
        public T EventData { get; private set; }

        public object GetEventData() {
            return this.EventData;
        }

        public string GetEventType() {
            return EventType;
        }
    }

    public interface IEvent : INotification {

        object GetEventData();
        string GetEventType();
    }
}
