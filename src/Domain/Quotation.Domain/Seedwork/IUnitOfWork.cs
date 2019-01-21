using System;
using System.Data;

namespace Quotation.Domain.Seedwork {
    public interface IUnitOfWork {
   
        void Commit();
    
        IDbConnection DbConnection();
    }
}
