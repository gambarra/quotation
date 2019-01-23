using System.Collections.Generic;

namespace Quotation.Application.Models {
    public  class ErrorResponse:BaseResponse {

        public ErrorResponse(List<string> erros) {
            this.Erros = erros;
        }
    }
}
