using System;
using System.Collections.Generic;
using System.Text;

namespace Quotation.Application.Models.Currency {
    public class CreateCurrencyRequest {

        public string Name { get; set; }
        public string CurrencyIso { get; set; }
    }
}
