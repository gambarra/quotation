using System;

namespace Quotation.Application.Models {
    public class CreateCorrelationPairRequest {

        public string BaseCurrency { get; set; }
        public string QuoteCurrency { get; set; }
        public decimal Coefficient { get; set; }
        public DateTime QuoquotationDate { get; set; }
    }
}
