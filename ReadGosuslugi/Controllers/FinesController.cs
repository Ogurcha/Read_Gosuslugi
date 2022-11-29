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
    public class FinesController : Controller
    {
        private readonly IFinesManager _commonLogicManager;
        private readonly ILogger<FinesController> _logger;

        public FinesController(IFinesManager commonLogicManager,
            ILogger<FinesController> logger)
        {
            _commonLogicManager = commonLogicManager;
            _logger = logger;
        }

        [HttpGet]
        [SweepNetResponseExceptionFilter]
        [Route("FinesByInn")]
        public async Task<IActionResult> GetDebtByInn([FromQuery] string inn)
        {
            _logger.LogInformation("Starting fines by inn request");
            var result = await _commonLogicManager.GetFinesByInn(inn.ToString());
            var responseList = new SweepNetResponseList<Fine> { List = result };

            return Ok(responseList);
        }

        [HttpGet]
        [SweepNetResponseExceptionFilter]
        [Route("FinesByPassport")]
        public async Task<IActionResult> GetFinesByPassport([FromQuery] string passport)
        {
            _logger.LogInformation("Starting fines by passport request");
            var result = await _commonLogicManager.GetFinesByPassport(passport);
            var responseList = new SweepNetResponseDataWithTotal<Fine>(result);

            return Ok(responseList);
        }

        [HttpGet]
        [SweepNetResponseExceptionFilter]
        [Route("FinesBySts")]
        public async Task<IActionResult> GetFinesBySts([FromQuery] string sts)
        {
            _logger.LogInformation("Starting fines by sts request");
            var result = await _commonLogicManager.GetFinesBySts(sts);
            var responseList = new SweepNetResponseDataWithTotal<Fine>(result);

            return Ok(responseList);
        }
    }
}
