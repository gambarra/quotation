using Dapper;
using Quotation.Infra.Data.Seedwork;
using Quotation.Queries.Aggregates.QuotationAgg.Models;
using Quotation.Queries.Aggregates.QuotationAgg.Repository;
using System.Collections.Generic;
using System.Data.SqlClient;
using ExpressionExtensionSQL.Dapper;
using Quotation.Helper;
using ExpressionExtensionSQL;
using ExpressionExtensionSQL.Extensions;
using System.Linq;

namespace Quotation.Infra.Data.Repositories {
    public class QuotationQueriesRepository : IQuotationQueriesRepository {

        private readonly Context context;

        public QuotationQueriesRepository(Context context) {
            this.context = context;
           
        }
        public IList<QuotationModel> Find(Specification<QuotationModel> specification) {

            Configuration.GetInstance().Entity<QuotationModel>().ToTable("VwQuotation");
          
            string query = $@"
                    SELECT * FROM (
                    SELECT baseCurrency.IsoCode AS BaseCurrencyIso,
	                        quoteCurrency.IsoCode as QuoteCurrencyIso,
	                        pair.Coefficient AS Quotation,
		                    pair.QuotationDate 
                    FROM Quotation.CorrelationPair as pair
		                INNER JOIN Quotation.Currency as baseCurrency on 
					            pair.BaseCurrencyId=baseCurrency.Id 
		                INNER JOIN Quotation.Currency as quoteCurrency on 
					            pair.QuoteCurrencyId=quoteCurrency.Id)  AS VwQuotation
                        {{where}}";

            var connection = (SqlConnection)this.context.GetConnection();

            var filter = specification.SatisfiedBy();
            return connection.Query<QuotationModel>(query,expression: filter).ToList();
            
        }
    }
}
