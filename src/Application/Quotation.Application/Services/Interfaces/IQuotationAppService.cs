
using Quotation.Application.Models;
using Quotation.Application.Models.Quotation;
using Quotation.Queries.Aggregates.QuotationAgg.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quotation.Application.Services.Interfaces {
    public interface IQuotationAppService {

        Task<CreateCorrelationPairResponse> CreateAsync(CreateCorrelationPairRequest request);
        IList<QuotationModel> GetQuotations(GetQuotationRequest request);
    }
}
