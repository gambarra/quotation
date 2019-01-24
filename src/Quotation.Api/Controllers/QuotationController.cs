using Microsoft.AspNetCore.Mvc;
using Quotation.Application.Models;
using Quotation.Application.Models.Correlation;
using Quotation.Application.Models.Quotation;
using Quotation.Application.Services.Interfaces;
using Swashbuckle.AspNetCore.Examples;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Quotation.Api.Controllers {

    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class QuotationController : ControllerBase {

        private readonly IQuotationAppService quotationAppService;
        public QuotationController(IQuotationAppService quotationAppService) {

            this.quotationAppService = quotationAppService ?? throw new ArgumentNullException(nameof(quotationAppService));
        }

        /// <summary>
        /// Create Quotation
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> Create(CreateCorrelationPairRequest request) {

            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorResponse());

            var response = await quotationAppService.CreateAsync(request);
            if (response.Success)
                return StatusCode(201);
            else
                return BadRequest(response.Erros);
        }
        /// <summary>
        /// Get Quotation by filter
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetQuotation([FromQuery]GetQuotationRequest query) {

            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorResponse());

            var result = quotationAppService.GetQuotations(query);
            return Ok(result);
        }
    }
}
