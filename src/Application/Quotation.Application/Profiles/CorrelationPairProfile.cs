using Quotation.Application.Models;
using Quotation.Domain.Aggregates.QuotationAgg;
using Quotation.Domain.Aggregates.QuotationAgg.Commands;
using Quotation.Domain.Seedwork;

namespace Quotation.Application.Profiles {
    public class CorrelationPairProfile : AutoMapper.Profile {

        public CorrelationPairProfile() {
            MapCreateCorrelationPair();
        }

        private void MapCreateCorrelationPair() {
            CreateMap<CreateCorrelationPairRequest, CreateCorrelationPairCommand>()
               .ForMember(p => p.Coefficient, opt => opt.MapFrom(o => o.Coefficient))
               .ForMember(p => p.QuotationDate, opt => opt.MapFrom(o => o.QuotationDate))
               .ForMember(p => p.QuoteCurrencyId, opt => opt.Ignore())
               .ForMember(p => p.BaseCurrencyId, opt => opt.Ignore());

            CreateMap<CommandResult<CorrelationPair>, CreateCorrelationPairResponse>()
                .ForMember(d => d.Success, opt => opt.MapFrom(o => o.IsSuccess))
                .ForMember(d => d.Erros, opt => opt.MapFrom(o => o.Erros));
        }
    }
}
