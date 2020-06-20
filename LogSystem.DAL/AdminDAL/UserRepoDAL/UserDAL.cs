using LogSystem.Core.CoreDAL;
using LogSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogSystem.DAL.AdminDAL.UserRepoDAL
{
    public class UserDAL : CRUD<User>, IUserDAL
    {
        private readonly LogContext _ctx;

        public UserDAL(LogContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public async Task<User> AddedOrUpdatedUser(int userId)
        {
            return await _ctx.Users.Include(m => m.Role).Where(m => m.UserId == userId).FirstOrDefaultAsync();
        }

        public async Task<bool> CheckUserByUserId(int userId)
        {
            return await _ctx.Users.AnyAsync(m => m.UserId == userId);
        }

        public async Task<bool> CheckUserExist(string userName, string password, int userId)
        {
            return await _ctx.Users.AnyAsync(m => m.UserName.ToLower() == userName.ToLower() && m.Password == password && m.UserId != userId);
        }

        public async Task<IEnumerable<User>> Get()
        {
            return await _ctx.Users.Include(m => m.Role).OrderByDescending(m => m.CreatedDate).ToListAsync();
        }

        public async Task<User> Get(int userId)
        {
            return await _ctx.Users.Include(m => m.Role).Where(m => m.UserId == userId).FirstOrDefaultAsync();
        }

        public string UserPassword(int userId)
        {
            return _ctx.Users.Where(m => m.UserId == userId).FirstOrDefault().Password;
        }

        public async Task<int> Put(User user)
        {
            var userTracker = _ctx.Set<User>().Local
                 .FirstOrDefault(entry => entry.UserId.Equals(user.UserId));
            if (userTracker != null)
            {
                _ctx.Entry(userTracker).State = EntityState.Detached;
            }
            _ctx.Entry(user).State = EntityState.Modified;
            _ctx.Entry(user).Property("Password").IsModified = false;
            _ctx.Entry(user).Property("CreatedDate").IsModified = false;
            user.UpdatedDate = DateTime.Now;
            await _ctx.SaveChangesAsync();
            return user.UserId;
        }
    }
}
