using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quotation.Application.Models;
using Quotation.Application.Services.Interfaces;

namespace Quotation.Api.Controllers {
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase {


        public CurrencyController(ICurrencyAppService currencyAppService) {
            this.currencyAppService = currencyAppService ?? throw new ArgumentNullException(nameof(currencyAppService));
        }

        private readonly ICurrencyAppService currencyAppService;

        [HttpPost]
        public async Task<ActionResult<bool>> Create(CreateCurrencyRequest request) {
            var response = await currencyAppService.CreateAsync(request);
            if (response.IsSuccess())
                return Ok(response);
            else
                return BadRequest(response.Error);
        }

    }
}