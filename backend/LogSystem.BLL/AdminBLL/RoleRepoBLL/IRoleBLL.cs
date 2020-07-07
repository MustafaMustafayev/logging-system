using LogSystem.DTO.AdminDTO.RoleRepoDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LogSystem.DAL.AdminBLL.RoleRepoBLL
{
    public interface IRoleBLL
    {
        Task<IEnumerable<RoleFilterDTO>> RoleFilter();
    }
}
