using Microsoft.AspNetCore.Mvc;
using Quotation.Application.GraphQL.Queries;
using Quotation.Application.Models;
using Quotation.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quotation.Api.Controllers {
    [Route("api/v1/[controller]")]
    [ApiController]
    public class QuotationController: ControllerBase {

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
        
        [HttpPost("query")]
        public  async Task<IActionResult> Post([FromBody]GraphQLQuery query) {
            var result = await quotationAppService.GetQuotations(query);

            if (result.Errors?.Count > 0) {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}
