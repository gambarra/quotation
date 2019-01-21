using MediatR;
using Quotation.Domain.Seedwork;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Quotation.Domain.Aggregates.QuotationAgg.Events.Handler {
    public class CorrelationPairEventHandler:
        INotificationHandler<CorrelationPairCreatedEvent> {

        public CorrelationPairEventHandler(IEventBus eventBus) {
            this.eventBus = eventBus;
        }

        private readonly IEventBus eventBus;

        public Task Handle(CorrelationPairCreatedEvent notification, CancellationToken cancellationToken) {
            this.eventBus.AddEvent(notification);
            return Task.CompletedTask;
        }
    }
}
