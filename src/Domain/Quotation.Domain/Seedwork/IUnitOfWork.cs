using System;
using System.Data;

namespace Quotation.Domain.Seedwork {
    public interface IUnitOfWork:IDisposable {
   
        void Commit();
        void Rollback();
        IDbConnection DbConnection();
    }
}
