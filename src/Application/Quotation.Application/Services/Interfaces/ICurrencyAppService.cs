using Quotation.Application.Models;
using System;
using System.Threading.Tasks;

namespace Quotation.Application.Services.Interfaces {
    public interface ICurrencyAppService : IDisposable {

        Task<CreateCurrencyResponse> CreateAsync(CreateCurrencyRequest request);
        Task<UpdateCurrencyResponse> UpdateAsync(UpdateCurrencyRequest request);
    }
}
