using System;
using System.Threading.Tasks;
using LogSystem.BLL.AdminBLL.CompanyRepoBLL;
using LogSystem.Core.Utility;
using LogSystem.DTO.AdminDTO.CompanyRepoDTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LogSystem.Admin.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyBLL _company;
        public CompanyController(ICompanyBLL company)
        {
            _company = company;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _company.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(Messages.GeneralError);
            }
        }

        [HttpGet("{companyId}")]
        public async Task<IActionResult> Get(int companyId)
        {
            try
            {
                return Ok(await _company.Get(companyId));
            }
            catch (Exception ex)
            {
                return BadRequest(Messages.GeneralError);
            }
        }

        [HttpGet("companyFilter")]  
        public async Task<IActionResult> CompanyFilter()
        {
            try
            {
                return Ok(await _company.CompanyFilter());
            }
            catch (Exception ex)
            {
                return BadRequest(Messages.GeneralError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(CompanyAddDTO companyAddDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(Messages.InvalidModel);
                }
                return Ok(await _company.Post(companyAddDTO));
            }
            catch (Exception ex)
            {
                return BadRequest(Messages.GeneralError);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(CompanyDTO companyDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(Messages.InvalidModel);
                }
                if(!(await _company.CheckCompanyExist(companyDTO.CompanyId)))
                {
                    return BadRequest(Messages.CompanyNotExist);
                }
                return Ok(await _company.Put(companyDTO));
            }
            catch (Exception ex)
            {
                return BadRequest(Messages.GeneralError);
            }
        }

        [HttpDelete("{companyId}")]
        public async Task<IActionResult> Delete(int companyId)
        {
            try
            {
                if (!(await _company.CheckCompanyExist(companyId)))
                {
                    return BadRequest(Messages.CompanyNotExist);
                }
                return Ok(await _company.Delete(companyId));
            }
            catch (Exception ex)
            {
                return BadRequest(Messages.GeneralError);
            }
        }
    }
}