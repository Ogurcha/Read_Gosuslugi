using Microsoft.AspNetCore.Mvc;
using ReadGosuslugi.Core.Interfaces.Applogic;
using ReadGosuslugi.Filters;
using System;
using System.Threading.Tasks;

namespace ReadGosuslugi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogExportController : Controller
    {
        private readonly ILogExportManager _logExportManager;

        public LogExportController(ILogExportManager logExportManager)
        {
            _logExportManager = logExportManager;
        }

        [HttpGet]
        [SweepNetResponseExceptionFilter]
        [Route("GetLogs")]
        public async Task<IActionResult> GetJudicalDebtsByPassport()
        {
            var response = await _logExportManager.GetLogDump();

            return Ok(response);
        }

        [HttpGet]
        [SweepNetResponseExceptionFilter]
        [Route("GetLogsByDate")]
        public async Task<IActionResult> GetJudicalDebtsByPassport([FromQuery] DateTime date)
        {
            var response = await _logExportManager.GetLogDump(date);

            return Ok(response);
        }

    }
}
