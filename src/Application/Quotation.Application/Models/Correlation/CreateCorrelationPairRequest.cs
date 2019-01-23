using System;

namespace Quotation.Application.Models {
    public class CreateCorrelationPairRequest {

        public string BaseCurrencyIso { get; set; }
        public string QuoteCurrencyIso { get; set; }
        public decimal Coefficient { get; set; }
        public DateTime QuotationDate { get; set; }
    }
}
