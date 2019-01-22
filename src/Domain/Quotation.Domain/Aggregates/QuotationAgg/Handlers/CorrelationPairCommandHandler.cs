using MediatR;
using Quotation.Domain.Aggregates.QuotationAgg.Commands;
using Quotation.Domain.Aggregates.QuotationAgg.Repository;
using Quotation.Domain.Seedwork;
using System.Threading;
using System.Threading.Tasks;

namespace Quotation.Domain.Aggregates.QuotationAgg.Handlers {
    public class CorrelationPairCommandHandler :
         IRequestHandler<CreateCorrelationPairCommand, CommandResult<CorrelationPair>> {

        private readonly ICorrelationPairRepository correlationPairRepository;

        public CorrelationPairCommandHandler(ICorrelationPairRepository correlationPairRepository) {
            this.correlationPairRepository = correlationPairRepository;
        }
        public async Task<CommandResult<CorrelationPair>> Handle(CreateCorrelationPairCommand request, CancellationToken cancellationToken) {
            var correlation = new CorrelationPair(request.BaseCurrencyId, request.QuoteCurrencyId, request.Coefficient);
            await correlationPairRepository.Add(correlation);
            return CommandResult<CorrelationPair>.Success(correlation);
        }
    }
}
