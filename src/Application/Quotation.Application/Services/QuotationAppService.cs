using MediatR;
using Quotation.Application.Models;
using Quotation.Application.Models.Quotation;
using Quotation.Application.Services.Interfaces;
using Quotation.Domain.Aggregates.CurrencyAgg.Repository;
using Quotation.Domain.Aggregates.QuotationAgg.Commands;
using Quotation.Domain.Seedwork;
using Quotation.Infra.Mapper;
using Quotation.Queries.Aggregates.QuotationAgg.Models;
using Quotation.Queries.Aggregates.QuotationAgg.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quotation.Application.Services {
    public class QuotationAppService : IQuotationAppService {

        private readonly ICurrencyRepository currencyRepository;
        private readonly IQuotationQueriesRepository quotationQueriesRepository;
        private readonly IMediator mediator;
        private readonly IUnitOfWork unitOfWork;

        public QuotationAppService(ICurrencyRepository currencyRepository,
            IQuotationQueriesRepository quotationQueriesRepository,
            IMediator mediator,
            IUnitOfWork unitOfWork) { 

            this.currencyRepository = currencyRepository;
            this.quotationQueriesRepository = quotationQueriesRepository;
            this.mediator = mediator;
            this.unitOfWork = unitOfWork;

        }
        public async Task<CreateCorrelationPairResponse> CreateAsync(CreateCorrelationPairRequest request) {

            var baseCurrency = currencyRepository.FindOneAsync(p => p.IsoCode == request.BaseCurrencyIso.ToUpper()).Result;
            if (baseCurrency == null)
                return new CreateCorrelationPairResponse()
                    .AddError<CreateCorrelationPairResponse>("Base Currency Not Exits");

            var quoteCurrency = currencyRepository.FindOneAsync(p => p.IsoCode == request.QuoteCurrencyIso.ToUpper()).Result;
            if (quoteCurrency == null)
                return new CreateCorrelationPairResponse()
                   .AddError<CreateCorrelationPairResponse>("Quote Currency Not Exits");

            var command = request.ProjectedAs<CreateCorrelationPairCommand>();
            command.BaseCurrencyId = baseCurrency.Id;
            command.QuoteCurrencyId = quoteCurrency.Id;

            var response = await mediator.Send(command);

            if (response.IsSuccess)
                unitOfWork.Commit();

            return response.ProjectedAs<CreateCorrelationPairResponse>();
        }

        public IList<QuotationModel> GetQuotations(GetQuotationRequest request) {
            return this.quotationQueriesRepository.Find(request.BuildFilter());
        }
    }
}
