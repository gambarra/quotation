using MediatR;
using Quotation.Application.Models;
using Quotation.Application.Services.Interfaces;
using Quotation.Domain.Aggregates.CurrencyAgg.Repository;
using Quotation.Domain.Aggregates.QuotationAgg.Commands;
using Quotation.Domain.Aggregates.QuotationAgg.Repository;
using Quotation.Infra.Mapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.Application.Services {
    public class QuotationAppService : IQuotationAppService {

        private readonly ICurrencyRepository currencyRepository;
        private readonly IMediator mediator;

        public QuotationAppService(ICurrencyRepository currencyRepository,
            IMediator mediator) {

            this.currencyRepository = currencyRepository;
            this.mediator = mediator;
          
        }
        public async Task<CreateCorrelationPairResponse> CreateAsync(CreateCorrelationPairRequest request) {

            var baseCurrency =  currencyRepository.FindOneAsync(p => p.IsoCode == request.BaseCurrency.ToLower()).Result;
            if (baseCurrency == null)
                throw new ArgumentException("Base Currency Not Exits");

            var quoteCurrency = currencyRepository.FindOneAsync(p => p.IsoCode == request.QuoteCurrency.ToLower()).Result;
            if (quoteCurrency == null)
                throw new ArgumentException("Quote Currency Not Exits");

            var command = request.ProjectedAs<CreateCorrelationPairCommand>();
            command.BaseCurrencyId = baseCurrency.Id;
            command.QuoteCurrencyId = quoteCurrency.Id;

            var response = await mediator.Send(command);
            return response.ProjectedAs<CreateCorrelationPairResponse>();
        }
    }
}
