using Microsoft.AspNetCore.Mvc.ModelBinding;
using Quotation.Application.Models;
using System.Linq;

namespace Quotation.Api {
    public static class ApiErrorMapper {

        public static ErrorResponse GetErrorResponse(this ModelStateDictionary modelState) {

            var errors = modelState.Values.SelectMany(v => v.Errors).Select(p => p.ErrorMessage.ToString());

            return new ErrorResponse(errors.ToList());
        }
    }
}
