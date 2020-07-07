using System;
using System.Threading.Tasks;
using LogSystem.BLL.AdminBLL.CompanyServiceRepoBLL;
using LogSystem.Core.Utility;
using LogSystem.DTO.AdminDTO.CompanyServiceDTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LogSystem.Admin.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyServiceController : ControllerBase
    {
        private readonly ICompanyServiceBLL _companyService; 
        public CompanyServiceController(ICompanyServiceBLL companyService)
        {
            _companyService = companyService;
        }

        [HttpGet("companyServices/{companyId}")]
        public async Task<IActionResult> CompanyServices(int companyId)
        {
            try
            {
                return Ok(await _companyService.CompanyServices(companyId));
            }
            catch (Exception ex)
            {
                return BadRequest(Messages.GeneralError);
            }
        }


        [HttpGet("{companyId}/{serviceId}")]
        public async Task<IActionResult> CompanyServices(int companyId, int serviceId)
        {
            try
            {
                return Ok(await _companyService.AdddedOrUpdatedCompanyService(companyId, serviceId));
            }
            catch (Exception ex)
            {
                return BadRequest(Messages.GeneralError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(CompanyServiceAddDTO companyServiceAddDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(Messages.InvalidModel);
                }          
                return Ok(await _companyService.Post(companyServiceAddDTO));
            }
            catch (Exception ex)
            {
                return BadRequest(Messages.GeneralError);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(CompanyServiceUpdateDTO companyServiceUpdateDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(Messages.InvalidModel);
                }
                return Ok(await _companyService.Put(companyServiceUpdateDTO));
            }
            catch (Exception ex)
            {
                return BadRequest(Messages.GeneralError);
            }
        }

        [HttpDelete("{companyServiceId}")]
        public async Task<IActionResult> Delete(int companyServiceId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(Messages.InvalidModel);
                }
                return Ok(await _companyService.Delete(companyServiceId));
            }
            catch (Exception ex)
            {
                return BadRequest(Messages.GeneralError);
            }
        }
    }
}