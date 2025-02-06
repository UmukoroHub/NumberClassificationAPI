using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using NumberClassificationAPI.Models;
using NumberClassificationAPI.Service;

namespace NumberClassificationAPI.Controllers
{
    [Route("api/classify-number")]
    [ApiController]
    public class NumberController : ControllerBase
    {

        private readonly ILogger<NumberController> _logger;
        private readonly INumberFact _numberFact;

        public NumberController(ILogger<NumberController> logger, INumberFact numberFact)
        {
            _logger = logger;
            _numberFact = numberFact;
        }


        [HttpGet]
        [Route("get-number-fact")]
        public async Task<IActionResult> Numberclassification([FromQuery] int number) 
        {
            _logger.LogInformation($"Entered into {nameof(Numberclassification)} endpoint");
            if (!IsValidNumber(number))
            {
                return BadRequest(new
                {
                    number = "alphabet",
                    error = true
                });
            }

            var result = await _numberFact.GenerateNumberFact(number);

            return Ok(result);

        }

        private bool IsValidNumber(int? number)
        {
            if (!number.HasValue)
            {
                return false;  // Reject null values (if nullable)
            }

            return true; // Accepts only valid positive integers
        }


    }
}
