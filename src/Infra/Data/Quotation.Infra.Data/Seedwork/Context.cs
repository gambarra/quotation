using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Quotation.Domain.Aggregates.CurrencyAgg;
using Quotation.Domain.Aggregates.QuotationAgg;
using Quotation.Infra.Data.Mapping;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;

namespace Quotation.Infra.Data.Seedwork {
    public class Context : DbContext {

        private DbConnection connection;

        public DbSet<Currency> Currency { get; set; }
        public DbSet<CorrelationPair> CorrelationPair { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            
            modelBuilder.ForSqlServerUseIdentityColumns();
            modelBuilder.HasDefaultSchema("Quotation");

            modelBuilder.ApplyConfiguration(new CurrencyMap());
            modelBuilder.ApplyConfiguration(new CorrelationPairMap());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var cnn = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(cnn);
            this.connection = new SqlConnection(cnn);         

        }

        public DbConnection GetConnection() => this.connection;
    }
}
