using Dapper;
using Quotation.Infra.Data.Seedwork;
using Quotation.Queries.Aggregates.QuotationAgg.Models;
using Quotation.Queries.Aggregates.QuotationAgg.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace Quotation.Infra.Data.Repositories {
    public class QuotationQueriesRepository : IQuotationQueriesRepository {

        private readonly Context context;

        public QuotationQueriesRepository(Context context) {
            this.context = context;
        }
        public IList<QuotationModel> Find(Expression<Func<QuotationModel, bool>> expression) {

            string query = $@"
                    SELECT baseCurrency.IsoCode AS BaseCurrencyIso,
	                        quoteCurrency.IsoCode as QuoteCurrencyIso,
	                        pair.Coefficient AS Quotation,
		                    pair.QuotationDate 
                    FROM Quotation.CorrelationPair as pair
		                INNER JOIN Quotation.Currency as baseCurrency on 
					            pair.BaseCurrencyId=baseCurrency.Id 
		                INNER JOIN Quotation.Currency as quoteCurrency on 
					            pair.QuoteCurrencyId=quoteCurrency.Id 
                        {{where}}";

            var connection = (SqlConnection)this.context.GetConnection();

            return connection.Query<QuotationModel>(query, expression).AsList();
        }
    }
}
