using Microsoft.AspNetCore.Mvc;
using Quotation.Application.Models;
using Quotation.Application.Models.Quotation;
using Quotation.Application.Services.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Quotation.Api.Controllers {
    [Route("api/v1/[controller]")]
    [ApiController]
    public class QuotationController : ControllerBase {

        private readonly IQuotationAppService quotationAppService;
        public QuotationController(IQuotationAppService quotationAppService) {

            this.quotationAppService = quotationAppService ?? throw new ArgumentNullException(nameof(quotationAppService));
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse>> Create(CreateCorrelationPairRequest request) {
            var response = await quotationAppService.CreateAsync(request);
            if (response.Success)
                return Ok(response);
            else
                return BadRequest(response.Erros);
        }

        [HttpGet]
        public IActionResult GetQuotation([FromQuery]GetQuotationRequest query) {

            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorResponse());

            var result = quotationAppService.GetQuotations(query);
            return Ok(result);
        }
    }
}
