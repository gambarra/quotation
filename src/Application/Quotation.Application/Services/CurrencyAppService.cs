using MediatR;
using Quotation.Application.Models;
using Quotation.Application.Models.Currency;
using Quotation.Application.Services.Interfaces;
using Quotation.Domain.Aggregates.CurrencyAgg.Commands;
using Quotation.Domain.Seedwork;
using Quotation.Infra.Mapper;
using System;
using System.Threading.Tasks;

namespace Quotation.Application.Services {
    public class CurrencyAppService :ICurrencyAppService{

        private readonly IMediator mediator;
        private readonly IUnitOfWork unitOfWork;

        public CurrencyAppService(IMediator mediator, IUnitOfWork unitOfWork) {
            this.mediator = mediator;
            this.unitOfWork = unitOfWork;

        }

        public async Task<CreateCurrencyResponse> CreateAsync(CreateCurrencyRequest request) {
            var response = await mediator.Send(request.ProjectedAs<CreateCurrencyCommand>());

            if (response.IsSuccess)
                unitOfWork.Commit();

            return response.ProjectedAs<CreateCurrencyResponse>();
        }



        public async Task<UpdateCurrencyResponse> UpdateAsync(UpdateCurrencyRequest request) {
            var command = request.ProjectedAs<UpdateCurrencyCommand>();
            var response = await mediator.Send(command);

            if (response.IsSuccess)
                unitOfWork.Commit();

            return response.ProjectedAs<UpdateCurrencyResponse>();
        }
    }
}
