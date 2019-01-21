using MediatR;
using Quotation.Domain.Aggregates.CurrencyAgg.Commands;
using Quotation.Domain.Aggregates.CurrencyAgg.Repository;
using Quotation.Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Quotation.Domain.Aggregates.CurrencyAgg.Handlers {
    public class CurrencyCommandHandler :
        CommandHandler<Currency>,
        IRequestHandler<CreateCurrencyCommand, Currency>,
        IRequestHandler<UpdateCurrencyCommand, Currency> {


        private readonly ICurrencyRepository currencyRepository;
        private readonly IUnitOfWork unitOfWork;

        public CurrencyCommandHandler(ICurrencyRepository currencyRepository,IUnitOfWork unitOfWork, IEventBus eventBus) : base(eventBus) {
            this.currencyRepository = currencyRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Currency> Handle(CreateCurrencyCommand request, CancellationToken cancellationToken) {

            var currency = new Currency(request.Name, request.CurrencyIso);
            await currencyRepository.Add(currency);
            unitOfWork.Commit();
            PublishEvents(currency);
            return currency;
        }


        public async Task<Currency> Handle(UpdateCurrencyCommand request, CancellationToken cancellationToken) {

            var currency = await currencyRepository.FindOneAsync(p => p.IsoCode.Equals(request.CurrencyIso.ToLower()));

            if (currency == null)
                throw new ArgumentException("Currency not found.");

            currency.Update(request.Name);
            await currencyRepository.Update(currency);
            unitOfWork.Commit();
            PublishEvents(currency);
            return currency;
        }



    }
}
