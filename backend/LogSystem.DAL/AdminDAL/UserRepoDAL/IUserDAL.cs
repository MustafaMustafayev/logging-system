using LogSystem.Core.CoreDAL;
using LogSystem.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogSystem.DAL.AdminDAL.UserRepoDAL
{
    public interface IUserDAL : ICRUD<User>
    {
        Task<IEnumerable<User>> Get();
        Task<User> Get(int userId);
        Task<User> AddedOrUpdatedUser(int userId);
        Task<bool> CheckUserExist(string userName, string password, int userId);
        Task<bool> CheckUserByUserId(int userId);
        public string UserPassword(int userId);
        public Task<int> Put(User user);  
    }
}
