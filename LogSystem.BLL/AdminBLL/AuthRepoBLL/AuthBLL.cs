using AutoMapper;
using LogSystem.DAL.AdminDAL.AuthRepoBLL;
using LogSystem.DTO.AdminDTO.AuthRepoDTO;
using LogSystem.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LogSystem.BLL.AdminBLL.AuthRepoBLL
{
    public class AuthBLL : IAuthBLL
    {
        private readonly IAuthDAL _auth;
        private readonly IMapper _mapper;
        public AuthBLL(IAuthDAL auth, IMapper mapper)
        {
            _auth = auth;
            _mapper = mapper;
        }

        public async Task<LoginUserDTO> Login(LoginDTO loginDTO)
        {
            User user = await _auth.Login(loginDTO);
            LoginUserDTO loginUserDTO = _mapper.Map<LoginUserDTO>(user);
            return loginUserDTO;
        }
    }
}
