using MediatR;
using Quotation.Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Quotation.Domain.Aggregates.CurrencyAgg.Events.Handler {
    public class CurrencyEventHander :
        INotificationHandler<CurrencyCreatedEvent>,
        INotificationHandler<CurrencyUpdatedEvent> {

        private readonly IEventBus eventBus;

        public CurrencyEventHander(IEventBus eventBus) {
            this.eventBus = eventBus;
        }

        public Task Handle(CurrencyCreatedEvent notification, CancellationToken cancellationToken) {
            this.eventBus.AddEvent(notification);
            return Task.CompletedTask;
        }

        public Task Handle(CurrencyUpdatedEvent notification, CancellationToken cancellationToken) {
            this.eventBus.AddEvent(notification);
            return Task.CompletedTask;
        }
    }
}
