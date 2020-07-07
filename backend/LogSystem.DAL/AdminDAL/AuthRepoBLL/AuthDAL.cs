using LogSystem.Core.CoreDAL;
using LogSystem.DTO.AdminDTO.AuthRepoDTO;
using LogSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace LogSystem.DAL.AdminDAL.AuthRepoBLL
{
    public class AuthDAL : CRUD<User>, IAuthDAL
    {
        private readonly LogContext _ctx;
        public AuthDAL(LogContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
        public async Task<User> Login(LoginDTO loginDTO)
        {
            User user = await _ctx.Users.Include(m => m.Role).Where(m => m.UserName == loginDTO.Username && m.Password == loginDTO.Password).FirstOrDefaultAsync();
            return user;
        }
    }
}
