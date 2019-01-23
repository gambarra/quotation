using GraphQL;
using Quotation.Application.GraphQL.Queries;
using Quotation.Application.Models;
using System.Threading.Tasks;

namespace Quotation.Application.Services.Interfaces {
    public interface IQuotationAppService {

        Task<CreateCorrelationPairResponse> CreateAsync(CreateCorrelationPairRequest request);
        Task<ExecutionResult> GetQuotations(GraphQLQuery query);
    }
}
