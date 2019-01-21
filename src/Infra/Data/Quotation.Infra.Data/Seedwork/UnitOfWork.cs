using Quotation.Domain.Seedwork;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Quotation.Infra.Data.Seedwork {
    public class UnitOfWork : IUnitOfWork {

        private readonly DbTransaction transaction;
        private readonly DbConnection connection;

        public UnitOfWork(string connectionString) {
            this.connection = new SqlConnection(connectionString);
            this.transaction = connection.BeginTransaction(isolationLevel: System.Data.IsolationLevel.ReadUncommitted);
        }

        public void Commit() => transaction.Commit();

        public IDbConnection DbConnection() => connection;

        public void Dispose() => transaction.Rollback();

        public void Rollback() => transaction.Rollback(); 
        
    }
}
