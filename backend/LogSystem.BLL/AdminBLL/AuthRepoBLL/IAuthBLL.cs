using LogSystem.DTO.AdminDTO.AuthRepoDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LogSystem.BLL.AdminBLL.AuthRepoBLL
{
    public interface IAuthBLL
    {
        Task<LoginUserDTO> Login(LoginDTO loginDTO);
    }
}
