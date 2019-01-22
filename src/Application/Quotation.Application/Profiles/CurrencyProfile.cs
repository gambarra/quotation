using Quotation.Application.Models.Currency;
using Quotation.Domain.Aggregates.CurrencyAgg;
using Quotation.Domain.Aggregates.CurrencyAgg.Commands;
using Quotation.Domain.Seedwork;

namespace Quotation.Application.Profiles {
    public class CurrencyProfile : AutoMapper.Profile {

        public CurrencyProfile() {

            MapCreateCurrency();

        }

        private void MapCreateCurrency() {
            CreateMap<CreateCurrencyRequest, CreateCurrencyCommand>()
                .ForMember(d => d.Name, opt => opt.MapFrom(o => o.Name))
                .ForMember(d => d.CurrencyIso, opt => opt.MapFrom(o => o.CurrencyIso.ToUpper()));

            CreateMap<CommandResult<Currency>, CreateCurrencyResponse>()
                .ForMember(d => d.Success, opt => opt.MapFrom(o => o.IsSuccess))
                .ForMember(d => d.Erros, opt => opt.MapFrom(o => o.Erros));
        }
    }
}
