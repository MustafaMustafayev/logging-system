using AutoMapper;
using LogSystem.DAL.AdminDAL.RoleRepoDAL;
using LogSystem.DTO.AdminDTO.RoleRepoDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogSystem.DAL.AdminBLL.RoleRepoBLL
{
    public class RoleBLL : IRoleBLL
    {
        private readonly IRoleDAL _role;
        private readonly IMapper _mapper;
        public RoleBLL(IRoleDAL role, IMapper mapper)
        {
            _role = role;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoleFilterDTO>> RoleFilter()
        {
            return _mapper.Map<IEnumerable<RoleFilterDTO>>(await _role.GetList());
        }
    }
}
