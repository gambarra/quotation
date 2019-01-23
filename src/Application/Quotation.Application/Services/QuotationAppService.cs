﻿using GraphQL;
using GraphQL.Types;
using MediatR;
using Quotation.Application.GraphQL.Queries;
using Quotation.Application.Models;
using Quotation.Application.Services.Interfaces;
using Quotation.Domain.Aggregates.CurrencyAgg.Repository;
using Quotation.Domain.Aggregates.QuotationAgg.Commands;
using Quotation.Domain.Aggregates.QuotationAgg.Repository;
using Quotation.Infra.Mapper;
using Quotation.Queries.Aggregates.QuotationAgg.Models;
using Quotation.Queries.Aggregates.QuotationAgg.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quotation.Application.Services {
    public class QuotationAppService : IQuotationAppService {

        private readonly ICurrencyRepository currencyRepository;
        private readonly IQuotationQueriesRepository quotationQueriesRepository;
        private readonly IMediator mediator;

        public QuotationAppService(ICurrencyRepository currencyRepository,
            IQuotationQueriesRepository quotationQueriesRepository,
            IMediator mediator) {

            this.currencyRepository = currencyRepository;
            this.quotationQueriesRepository = quotationQueriesRepository;
            this.mediator = mediator;

        }
        public async Task<CreateCorrelationPairResponse> CreateAsync(CreateCorrelationPairRequest request) {

            var baseCurrency = currencyRepository.FindOneAsync(p => p.IsoCode == request.BaseCurrency.ToUpper()).Result;
            if (baseCurrency == null)
                return new CreateCorrelationPairResponse()
                    .AddError<CreateCorrelationPairResponse>("Base Currency Not Exits");

            var quoteCurrency = currencyRepository.FindOneAsync(p => p.IsoCode == request.QuoteCurrency.ToUpper()).Result;
            if (quoteCurrency == null)
                return new CreateCorrelationPairResponse()
                   .AddError<CreateCorrelationPairResponse>("Quote Currency Not Exits");
          
            var command = request.ProjectedAs<CreateCorrelationPairCommand>();
            command.BaseCurrencyId = baseCurrency.Id;
            command.QuoteCurrencyId = quoteCurrency.Id;

            var response = await mediator.Send(command);
            return response.ProjectedAs<CreateCorrelationPairResponse>();
        }

        public async Task<ExecutionResult> GetQuotations(GraphQLQuery query) {
            var inputs = query.Variables.ToInputs();

            var schema = new Schema() {
                Query = new QuotationQuery(this.quotationQueriesRepository)
            };

            return await new DocumentExecuter().ExecuteAsync(_ => {
                _.Schema = schema;
                _.Query = query.Query;
                _.OperationName = query.OperationName;
                _.Inputs = inputs;
            });
        }
    }
}
