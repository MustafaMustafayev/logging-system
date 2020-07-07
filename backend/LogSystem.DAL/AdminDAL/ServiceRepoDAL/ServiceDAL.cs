using LogSystem.Core.CoreDAL;
using LogSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LogSystem.DAL.AdminDAL.ServiceRepoDAL
{
    public class ServiceDAL : CRUD<Service>, IServiceDAL
    {
        private readonly LogContext _ctx;
        public ServiceDAL(LogContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public async Task<bool> CheckServiceExist(int serviceId)
        {
            return await _ctx.Services.AnyAsync(m => m.ServiceId == serviceId);
        }
    }
}
