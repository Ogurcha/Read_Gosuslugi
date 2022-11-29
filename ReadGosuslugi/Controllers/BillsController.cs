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
    public class BillsController : Controller
    {
        private readonly IBillsManager _billsManager;
        private readonly ILogger<BillsController> _logger;

        public BillsController(IBillsManager billsManager,
            ILogger<BillsController> logger)
        {
            _billsManager = billsManager;
            _logger = logger;
        }

        [HttpGet]
        [SweepNetResponseExceptionFilter]
        [Route("BillsByPassport")]
        public async Task<IActionResult> GetBillsByPassport([FromQuery] string passport)
        {
            _logger.LogInformation("Starting bills by passport request");
            var result = await _billsManager.GetBillsByPassport(passport);
            var responseList = new SweepNetResponseDataWithTotal<ServiceBill>(result);

            return Ok(responseList);
        }

        [HttpGet]
        [SweepNetResponseExceptionFilter]
        [Route("BillsBySnils")]
        public async Task<IActionResult> GetBillsBySnils([FromQuery] string snils)
        {
            _logger.LogInformation("Starting bills by snilds request");
            var result = await _billsManager.GetBillsBySnils(snils);
            var responseList = new SweepNetResponseDataWithTotal<ServiceBill>(result);

            return Ok(responseList);
        }
    }
}
