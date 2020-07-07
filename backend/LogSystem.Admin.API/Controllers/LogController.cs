using System;
using System.Threading.Tasks;
using LogSystem.BLL.AdminBLL.LogRepoBLL;
using LogSystem.Core.Utility;
using Microsoft.AspNetCore.Mvc;

namespace LogSystem.Admin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly ILogBLL _log;
        public LogController(ILogBLL log)
        {
            _log = log;
        }

        [HttpGet("{pageNumber}")]
        public async Task<IActionResult> Logs(int pageNumber)
        {
            try
            {
                return Ok(await _log.Logs(pageNumber));
            }
            catch (Exception ex)
            {
                return BadRequest(Messages.GeneralError);
            }
        }

        [HttpGet("logChartInfo")]
        public async Task<IActionResult> LogChartInfo()
        {
            try
            {
                return Ok(await _log.LogChartInfo());
            }
            catch (Exception ex)
            {
                return BadRequest(Messages.GeneralError);
            }
        }

        [HttpGet("logIO/{requestId}")]
        public async Task<IActionResult> logIO(int requestId)
        {
            try
            {
                return Ok(await _log.LogIO(requestId));
            }
            catch (Exception ex)
            {
                return BadRequest(Messages.GeneralError);
            }
        }
    }
}