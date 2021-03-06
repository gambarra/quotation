﻿using MediatR;
using Quotation.Domain.Aggregates.QuotationAgg.Commands;
using Quotation.Domain.Aggregates.QuotationAgg.Repository;
using Quotation.Domain.Seedwork;
using System.Threading;
using System.Threading.Tasks;

namespace Quotation.Domain.Aggregates.QuotationAgg.Handlers {
    public class CorrelationPairCommandHandler : CommandHandler<CorrelationPair>,
         IRequestHandler<CreateCorrelationPairCommand, CommandResult<CorrelationPair>> {

        private readonly ICorrelationPairRepository correlationPairRepository;


        public CorrelationPairCommandHandler(ICorrelationPairRepository correlationPairRepository,IUnitOfWork unitOfWork):base(unitOfWork) {
            this.correlationPairRepository = correlationPairRepository;
        }
        public async Task<CommandResult<CorrelationPair>> Handle(CreateCorrelationPairCommand request, CancellationToken cancellationToken) {

            var correlation = await correlationPairRepository.FindOneAsync(p => p.BaseCurrencyId == request.BaseCurrencyId
                                                                            && p.QuoteCurrencyId == request.QuoteCurrencyId 
                                                                            && p.CreatedAt == request.QuotationDate.Date);

            if(correlation!=null)
                return CommandResult<CorrelationPair>.Fail(correlation, "CorrelationPair already exists");

            correlation = new CorrelationPair(request.BaseCurrencyId, request.QuoteCurrencyId, request.Coefficient, request.QuotationDate);
            await correlationPairRepository.Add(correlation);
            this.PublishEvents(correlation);
            return CommandResult<CorrelationPair>.Success(correlation);
        }
    }
}
