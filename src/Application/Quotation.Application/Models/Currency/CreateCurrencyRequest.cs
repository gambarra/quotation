using System.ComponentModel.DataAnnotations;

namespace Quotation.Application.Models.Currency {
    public class CreateCurrencyRequest {
        [Required]
        public string Name { get; set; }
        [Required]
        public string CurrencyIso { get; set; }
    }
}
