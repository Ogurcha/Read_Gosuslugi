using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReadGosuslugi.Controllers.ControllerContracts;
using ReadGosuslugi.Core.Dtos;
using ReadGosuslugi.Core.Interfaces.Applogic;
using ReadGosuslugi.Filters;
using System.Threading.Tasks;

namespace ReadGosuslugi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateDutiesController : Controller
    {
        private readonly IStateDutiesManager _stateDutiesManager;
        private readonly ILogger<JudicalDebtsController> _logger;

        public StateDutiesController(IStateDutiesManager stateDutiesManager,
            ILogger<JudicalDebtsController> logger)
        {
            _stateDutiesManager = stateDutiesManager;
            _logger = logger;
        }

        [HttpGet]
        [SweepNetResponseExceptionFilter]
        [Route("DutiesByPassport")]
        public async Task<IActionResult> GetDutiesByPassport([FromQuery] string passport)
        {
            _logger.LogInformation("Starting duties by passport request");
            var result = await _stateDutiesManager.GetDutiesByPassport(passport);
            var response = new SweepNetResponseDataWithTotal<StateDuty>(result);

            return Ok(response);
        }

        [HttpGet]
        [SweepNetResponseExceptionFilter]
        [Route("DutiesByInn")]
        public async Task<IActionResult> GetDutiesByInn([FromQuery] string inn)
        {
            _logger.LogInformation("Starting duties by inn request");
            var result = await _stateDutiesManager.GetDutiesByInn(inn);
            var response = new SweepNetResponseDataWithTotal<StateDuty>(result);

            return Ok(response);
        }

        [HttpGet]
        [SweepNetResponseExceptionFilter]
        [Route("DutiesBySnils")]
        public async Task<IActionResult> GetDutiesBySnils([FromQuery] string snils)
        {
            _logger.LogInformation("Starting duties by snils request");
            var result = await _stateDutiesManager.GetDutiesBySnils(snils);
            var response = new SweepNetResponseDataWithTotal<StateDuty>(result);

            return Ok(response);
        }
    }
}
