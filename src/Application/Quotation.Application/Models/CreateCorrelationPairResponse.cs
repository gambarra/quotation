namespace Quotation.Application.Models {
    public class CreateCorrelationPairResponse {
        public string BaseCurrency { get; set; }
        public string QuoteCurrency { get; set; }
        public decimal Coefficient { get; set; }
    }
}
