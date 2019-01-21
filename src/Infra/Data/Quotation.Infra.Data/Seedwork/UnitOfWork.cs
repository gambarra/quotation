using Quotation.Domain.Seedwork;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Quotation.Infra.Data.Seedwork {
    public class UnitOfWork : IUnitOfWork {


        private readonly Context context;
        public UnitOfWork(Context context) {
            this.context = context;
        }

        public void Commit() => context.SaveChanges();

        public IDbConnection DbConnection() => context.GetConnection();
    
    }
}
