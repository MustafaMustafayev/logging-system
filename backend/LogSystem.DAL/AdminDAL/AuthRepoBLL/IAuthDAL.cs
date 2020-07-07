using LogSystem.Core.CoreDAL;
using LogSystem.DTO.AdminDTO.AuthRepoDTO;
using LogSystem.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LogSystem.DAL.AdminDAL.AuthRepoBLL
{
    public interface IAuthDAL : ICRUD<User>
    {
        Task<User> Login(LoginDTO loginDTO);
    }
}
