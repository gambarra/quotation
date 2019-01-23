using Newtonsoft.Json;
using Quotation.Helper;
using Quotation.Queries.Aggregates.QuotationAgg.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Quotation.Application.Models.Quotation {
    public class GetQuotationRequest {

        [Required]
        [StringLength(maximumLength: 3, MinimumLength = 3)]
        public string BaseCurrencyIso { get; set; }
        [Required]
        [StringLength(maximumLength: 3, MinimumLength = 3)]
        public string QuoteCurrencyIso { get; set; }
        public DateTime? QuotationDateStart { get; set; }
        public DateTime? QuotationDateEnd { get; set; }

        public Specification<QuotationModel> BuildFilter() {

            Specification<QuotationModel> filter =
                DirectSpecification<QuotationModel>
                .Build(p => p.BaseCurrencyIso == this.BaseCurrencyIso
                    && p.QuoteCurrencyIso == this.QuoteCurrencyIso);

            if (this.QuotationDateEnd.HasValue)
                filter &= DirectSpecification<QuotationModel>
                    .Build(p => p.QuotationDate <= this.QuotationDateEnd.Value);

            if (this.QuotationDateStart.HasValue)
                filter &= DirectSpecification<QuotationModel>
                    .Build(p => p.QuotationDate >= this.QuotationDateStart.Value);

            return filter;
        }
    }
}
