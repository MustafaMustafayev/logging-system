using LogSystem.Core.CoreDAL;
using LogSystem.Entities;

namespace LogSystem.DAL.AdminDAL.RoleRepoDAL
{
    public class RoleDAL : CRUD<Role>, IRoleDAL
    {
        private readonly LogContext _ctx;
        public RoleDAL(LogContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }   

        string ok()
        {
            return null;
        }
    }
}
