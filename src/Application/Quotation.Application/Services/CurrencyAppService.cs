using MediatR;
using Quotation.Application.Models;
using Quotation.Application.Services.Interfaces;
using Quotation.Domain.Aggregates.CurrencyAgg.Commands;
using Quotation.Infra.Mapper;
using System;
using System.Threading.Tasks;

namespace Quotation.Application.Services {
    public class CurrencyAppService :ICurrencyAppService{

        private readonly IMediator mediator;

        public CurrencyAppService(IMediator mediator) {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        }

        public async Task<CreateCurrencyResponse> CreateAsync(CreateCurrencyRequest request) {
            var response = await mediator.Send(request.ProjectedAs<CreateCurrencyCommand>());
            return response.ProjectedAs<CreateCurrencyResponse>();
        }

        public void Dispose() {
            throw new NotImplementedException();
        }

        public async Task<UpdateCurrencyResponse> UpdateAsync(UpdateCurrencyRequest request) {
            var command = request.ProjectedAs<UpdateCurrencyCommand>();
            var response = await mediator.Send(command);
            return response.ProjectedAs<UpdateCurrencyResponse>();
        }
    }
}
