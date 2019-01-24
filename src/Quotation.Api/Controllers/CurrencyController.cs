using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quotation.Application.Models;
using Quotation.Application.Models.Currency;
using Quotation.Application.Services.Interfaces;
using Swashbuckle.AspNetCore.Examples;

namespace Quotation.Api.Controllers {
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase {


        public CurrencyController(ICurrencyAppService currencyAppService) {
            this.currencyAppService = currencyAppService ?? throw new ArgumentNullException(nameof(currencyAppService));
        }

        private readonly ICurrencyAppService currencyAppService;
        /// <summary>
        /// Create Currency
        /// </summary>
        /// <param name="request"></param>
        /// <response code="201">Currency Created</response>
        [HttpPost]       
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> Create(CreateCurrencyRequest request) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorResponse());

            var response = await currencyAppService.CreateAsync(request);
            if (response.Success)
                return StatusCode(201); 
            else
                return BadRequest(response.Erros);
        }

    }
}