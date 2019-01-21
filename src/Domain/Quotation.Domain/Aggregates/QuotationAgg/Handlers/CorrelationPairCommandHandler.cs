using MediatR;
using Quotation.Domain.Aggregates.QuotationAgg.Commands;
using Quotation.Domain.Aggregates.QuotationAgg.Repository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Quotation.Domain.Aggregates.QuotationAgg.Handlers {
    class CorrelationPairCommandHandler :
        IRequestHandler<CreateCorrelationPairCommand, CorrelationPair> {

        private readonly ICorrelationPairRepository correlationPairRepository;

        public CorrelationPairCommandHandler(ICorrelationPairRepository correlationPairRepository) {
            this.correlationPairRepository = correlationPairRepository;
        }
        public async Task<CorrelationPair> Handle(CreateCorrelationPairCommand request, CancellationToken cancellationToken) {
            var correlation = new CorrelationPair(request.BaseCurrencyId, request.QuoteCurrencyId, request.Coefficient);
            await correlationPairRepository.Add(correlation);
            return correlation;
        }
    }
}
