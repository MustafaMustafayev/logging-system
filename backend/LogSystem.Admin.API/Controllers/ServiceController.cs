using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogSystem.BLL.AdminBLL.ServiceRepoBLL;
using LogSystem.Core.Utility;
using LogSystem.DTO.AdminDTO.ServiceRepoDTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogSystem.Admin.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceBLL _service;
        public ServiceController(IServiceBLL service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _service.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(Messages.GeneralError);
            }
        }

        [HttpGet("{serviceId}")]
        public async Task<IActionResult> Get(int serviceId)
        {
            try
            {
                return Ok(await _service.Get(serviceId));
            }
            catch (Exception ex)
            {
                return BadRequest(Messages.GeneralError);
            }
        }

        [HttpGet("serviceFilter")]
        public async Task<IActionResult> ServiceFilter()
        {
            try
            {
                return Ok(await _service.ServiceFilter());
            }
            catch (Exception ex)
            {
                return BadRequest(Messages.GeneralError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ServiceAddDTO serviceAddDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(Messages.InvalidModel);
                }
                return Ok(await _service.Post(serviceAddDTO));
            }
            catch (Exception ex)
            {
                return BadRequest(Messages.GeneralError);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(ServiceDTO serviceDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(Messages.InvalidModel);
                }
                if(!(await _service.CheckServiceExist(serviceDTO.ServiceId)))
                {
                    return BadRequest(Messages.ServiceNotExist);
                }
                return Ok(await _service.Put(serviceDTO));
            }
            catch (Exception ex)
            {
                return BadRequest(Messages.GeneralError);
            }
        }

        [HttpDelete("{serviceId}")]
        public async Task<IActionResult> Delete(int serviceId)
        {
            try
            {
                if (!(await _service.CheckServiceExist(serviceId)))
                {
                    return BadRequest(Messages.ServiceNotExist);
                }
                return Ok(await _service.Delete(serviceId));
            }
            catch (Exception ex)
            {
                return BadRequest(Messages.GeneralError);
            }
        }
    }
}