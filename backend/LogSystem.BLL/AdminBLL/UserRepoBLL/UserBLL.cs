using AutoMapper;
using LogSystem.DAL.AdminDAL.RoleRepoDAL;
using LogSystem.DAL.AdminDAL.UserRepoDAL;
using LogSystem.DTO.AdminDTO.UserRepoDTO;
using LogSystem.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogSystem.BLL.AdminBLL.UserRepoBLL
{
    public class UserBLL : IUserBLL
    {
        private readonly IUserDAL _user;
        private readonly IRoleDAL _role;
        private readonly IMapper _mapper;

        public UserBLL(IUserDAL user, IRoleDAL role, IMapper mapper)
        {
            _user = user;
            _role = role;
            _mapper = mapper;
        }

        public async Task<bool> CheckUserByUserId(int userId)
        {
            return await _user.CheckUserByUserId(userId);
        }

        public async Task<bool> CheckUserExist(string userName, string password, int userId)
        {
            return await _user.CheckUserExist(userName, password, userId);
        }

        public async Task<int> Delete(int userId)
        {
            User user = await _user.Get(m => m.UserId == userId);
            user.DeletedDate = DateTime.Now;
            var deletedUser = await _user.Update(user);
            return deletedUser.UserId;
        }

        public async Task<UsersDTO> Post(UserAddDTO userAddDTO)
        {
            User user = _mapper.Map<User>(userAddDTO);
            user.CreatedDate = DateTime.Now;
            var response = await _user.Add(user);
            return _mapper.Map<UsersDTO>(await _user.AddedOrUpdatedUser(response.UserId));
        }

        public async Task UpdatePassword(UpdatePasswordDTO updatePasswordDTO)
        {
            User user = await _user.Get(m => m.UserId == updatePasswordDTO.UserId);
            user.Password = updatePasswordDTO.Password;
            user.UpdatedDate = DateTime.Now;
            await _user.Update(user);
        }

        public async Task<UserDTO> Get(int userId)
        {
            return _mapper.Map<UserDTO>(await _user.Get(userId));
        }

        public async Task<IEnumerable<UsersDTO>> Get()
        {
            return _mapper.Map<IEnumerable<UsersDTO>>(await _user.Get()); 
        }

        public string UserPassword(int userId)
        {
            return _user.UserPassword(userId);
        }

        public async Task<UsersDTO> Put(UserDTO userDTO)
        {
            User user = _mapper.Map<User>(userDTO);
            user.Role = await _role.Get(m => m.RoleId == userDTO.RoleId);
            int updatedUserId = await _user.Put(user);
            return _mapper.Map<UsersDTO>(await _user.AddedOrUpdatedUser(updatedUserId));
        }
    }
}
