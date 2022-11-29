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
    public class JudicalDebtsController : Controller
    {
        private readonly IJudicalDebtManager _judicalDebtManager;
        private readonly ILogger<JudicalDebtsController> _logger;

        public JudicalDebtsController(IJudicalDebtManager judicalDebtManager,
            ILogger<JudicalDebtsController> logger)
        {
            _judicalDebtManager = judicalDebtManager;
            _logger = logger;
        }

        [HttpGet]
        [SweepNetResponseExceptionFilter]
        [Route("JudicalDebtsByPassport")]
        public async Task<IActionResult> GetJudicalDebtsByPassport([FromQuery] string passport)
        {
            _logger.LogInformation("Starting judical debts by passport request");
            var result = await _judicalDebtManager.GetJudicalDebtsByPassport(passport);
            var response = new SweepNetResponseDataWithTotal<JudicalDebt>(result);

            return Ok(response);
        }

        [HttpGet]
        [SweepNetResponseExceptionFilter]
        [Route("JudicalDebtsByInn")]
        public async Task<IActionResult> GetDutiesByInn([FromQuery] string inn)
        {
            _logger.LogInformation("Starting judical debts by inn request");
            var result = await _judicalDebtManager.GetJudicalDebtsByInn(inn);
            var response = new SweepNetResponseDataWithTotal<JudicalDebt>(result);

            return Ok(response);
        }

        [HttpGet]
        [SweepNetResponseExceptionFilter]
        [Route("JudicalDebtsBySnils")]
        public async Task<IActionResult> GetDutiesBySnils([FromQuery] string snils)
        {
            _logger.LogInformation("Starting judical debts by snils request");
            var result = await _judicalDebtManager.GetJudicalDebtsBySnuls(snils);
            var response = new SweepNetResponseDataWithTotal<JudicalDebt>(result);

            return Ok(response);
        }




    }
}
