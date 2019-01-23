using System;
using System.Collections.Generic;
using System.Data;

namespace Quotation.Domain.Seedwork {
    public interface IUnitOfWork {
   
        void Commit();
    
        IDbConnection DbConnection();

        void AddEvent(IEvent @event);

        void AddEvents(IReadOnlyCollection<IEvent> events);
    }
}
