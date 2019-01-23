using System;

namespace Quotation.Queries.Aggregates.QuotationAgg.Models {
    public class QuotationModel {

 
        public string BaseCurrencyIso { get; set; }
        public string QuoteCurrencyIso { get; set; }
        public decimal Quotation { get; set; }
        public DateTime QuotationDate { get; set; }
    }
}
