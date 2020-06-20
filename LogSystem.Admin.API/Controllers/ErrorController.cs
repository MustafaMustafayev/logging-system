using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogSystem.Core.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogSystem.Admin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [HttpGet("unAuthorized")]
        public IActionResult UnauthorizedCustomErrorResponse()
        {
            return Unauthorized();
        }

        [HttpGet("rootNotFound")]
        public IActionResult rootNotFound()
        {
            return BadRequest(Messages.RootNotFound);
        }

        [HttpGet("forbidden")]
        public IActionResult Forbidden()
        {
            return BadRequest(Messages.Forbidden);
        }

        [HttpGet("methodNotAllowed")]
        public IActionResult MethodNotAllowed()
        {
            return BadRequest(Messages.MethodNotAllowed);
        }
    }
}