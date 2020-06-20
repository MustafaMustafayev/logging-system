using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogSystem.BLL.AdminBLL.UserRepoBLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LogSystem.Core.Utility;
using LogSystem.DTO.AdminDTO.UserRepoDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace LogSystem.Admin.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBLL _user;
        private readonly IUtil _util;
        public UserController(IUserBLL user, IUtil util)
        {
            _user = user;
            _util = util;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _user.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(Messages.GeneralError);
            }
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> Get(int userId)
        {
            try
            {
                return Ok(await _user.Get(userId));
            }
            catch (Exception ex)
            {
                return BadRequest(Messages.GeneralError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserAddDTO userAddDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(Messages.InvalidModel);
                }
                userAddDTO.Password = _util.HashPassword(userAddDTO.Password);
                if ((await _user.CheckUserExist(userAddDTO.UserName, userAddDTO.Password, 0)))
                {
                    return BadRequest(Messages.UserExist);
                }
                return Ok(await _user.Post(userAddDTO));
            }
            catch (Exception ex)
            {
                return BadRequest(Messages.GeneralError);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(UserDTO userDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(Messages.InvalidModel);
                }
                if (!(await _user.CheckUserByUserId(userDTO.UserId)))
                {
                    return BadRequest(Messages.UserNotExist);
                }
                if ((await _user.CheckUserExist(userDTO.UserName, _user.UserPassword(userDTO.UserId), userDTO.UserId)))
                {
                    return BadRequest(Messages.UserExist);
                }
                return Ok(await _user.Put(userDTO));
            }
            catch (Exception ex)
            {
                return BadRequest(Messages.GeneralError);
            }
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete(int userId)
        {
            try
            {
                if(!(await _user.CheckUserByUserId(userId)))
                {
                    return BadRequest(Messages.UserNotExist);
                }
                return Ok(await _user.Delete(userId));
            }
            catch (Exception ex)
            {
                return BadRequest(Messages.GeneralError);
            }
        }

        [HttpPut("updatePassword")]
        public async Task<IActionResult> UpdatePassword(UpdatePasswordDTO updatePasswordDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(Messages.InvalidModel);
                }
                if (!(await _user.CheckUserByUserId(updatePasswordDTO.UserId)))
                {
                    return BadRequest(Messages.UserNotExist);
                }
                updatePasswordDTO.Password = _util.HashPassword(updatePasswordDTO.Password);
                UserDTO userDTO = await _user.Get(updatePasswordDTO.UserId);
                if ((await _user.CheckUserExist(userDTO.UserName, updatePasswordDTO.Password, userDTO.UserId)))
                {
                    return BadRequest(Messages.UserExist);
                }
                await _user.UpdatePassword(updatePasswordDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(Messages.GeneralError);
            }
        }
    }
}