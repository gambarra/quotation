using Quotation.Application.Models;
using System.Threading.Tasks;

namespace Quotation.Application.Services.Interfaces {
    public interface IQuotationAppService {

        Task<CreateCorrelationPairResponse> CreateAsync(CreateCorrelationPairRequest request);
    }
}
