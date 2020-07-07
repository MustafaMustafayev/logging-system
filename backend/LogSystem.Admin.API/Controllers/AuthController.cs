using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using LogSystem.BLL.AdminBLL.AuthRepoBLL;
using LogSystem.Core.Utility;
using LogSystem.DTO.AdminDTO.AuthRepoDTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace LogSystem.Admin.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthBLL _auth;
        private readonly IConfiguration _configuration;
        private readonly IUtil _util;
        public AuthController(IAuthBLL auth, IConfiguration configuration, IUtil util)
        {
            _auth = auth;
            _configuration = configuration;
            _util = util;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(Messages.InvalidModel);
                }
                loginDTO.Password = _util.HashPassword(loginDTO.Password);
                LoginUserDTO userDTO = await _auth.Login(loginDTO);
                if (userDTO != null)
                {
                    var claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, userDTO.UserId.ToString()));
                    claims.Add(new Claim(ClaimTypes.Role, userDTO.RoleName.ToString()));

                    var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration.GetSection("JWTSettings:SecretKey").Value));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(claims),
                        Expires = DateTime.Now.AddDays(1),
                        SigningCredentials = creds
                    };
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    string tokenValue = tokenHandler.WriteToken(token);

                    userDTO.Token = tokenValue;
                    userDTO.TokenExpireDate = tokenDescriptor.Expires?.ToString("MM/dd/yyyy HH:mm:ss");

                    return Ok(userDTO);
                }
                else
                {
                    return BadRequest(Messages.LoginFailed);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error occured");
            }
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            return Ok();
        }
    }
}