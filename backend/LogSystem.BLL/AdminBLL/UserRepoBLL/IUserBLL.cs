using LogSystem.DTO.AdminDTO.UserRepoDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LogSystem.BLL.AdminBLL.UserRepoBLL
{
    public interface IUserBLL
    {
        public Task<IEnumerable<UsersDTO>> Get();
        public Task<UsersDTO> Post(UserAddDTO userAddDTO);
        public Task<bool> CheckUserExist(string userName, string password, int userId);
        public Task<int> Delete(int userId);
        public Task<bool> CheckUserByUserId(int userId);
        public Task UpdatePassword(UpdatePasswordDTO updatePasswordDTO);
        public Task<UserDTO> Get(int userId);
        public string UserPassword(int userId);
        public Task<UsersDTO> Put(UserDTO userDTO);
    }
}
