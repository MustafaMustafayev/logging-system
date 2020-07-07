using System;
using System.Threading.Tasks;
using LogSystem.Core.Utility;
using LogSystem.DAL.AdminBLL.RoleRepoBLL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LogSystem.Admin.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleBLL _role;
        public RoleController(IRoleBLL role)
        {
            _role = role;
        }

        [HttpGet("roleFilter")]
        public async Task<IActionResult> RoleFilter()
        {
            try
            {
                return Ok(await _role.RoleFilter());
            }
            catch (Exception ex)
            {
                return BadRequest(Messages.GeneralError);
            }
        }
    }
}