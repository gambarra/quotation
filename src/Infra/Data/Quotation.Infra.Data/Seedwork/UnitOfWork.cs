using Quotation.Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Quotation.Infra.Data.Seedwork {
    public class UnitOfWork : IUnitOfWork {


        private readonly Context context;
        private readonly IEventBus eventBus;
        private List<IEvent> events;
        public UnitOfWork(Context context, IEventBus eventBus) {
            this.context = context;
            this.events = new List<IEvent>();
            this.eventBus = eventBus;
        }

        public void AddEvent(IEvent @event) {
            this.events.Add(@event);
        }

        public void AddEvents(IReadOnlyCollection<IEvent> events) {
            this.events.AddRange(events);
        }

        public void Commit() {
            context.SaveChanges();
            this.eventBus.AddEvents(this.events);
        }

        public IDbConnection DbConnection() => context.GetConnection();

    }
}
