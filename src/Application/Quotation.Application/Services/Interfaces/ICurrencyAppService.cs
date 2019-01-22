using Quotation.Application.Models.Currency;
using System;
using System.Threading.Tasks;

namespace Quotation.Application.Services.Interfaces {
    public interface ICurrencyAppService  {

        Task<CreateCurrencyResponse> CreateAsync(CreateCurrencyRequest request);
        Task<UpdateCurrencyResponse> UpdateAsync(UpdateCurrencyRequest request);
    }
}
