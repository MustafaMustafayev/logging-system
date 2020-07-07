using Dapper;
using LogSystem.Core.CoreDAL;
using LogSystem.DTO.AdminDTO.LogRepoDTO;
using LogSystem.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace LogSystem.DAL.AdminDAL.LogRepoDAL
{
    public class LogDAL : CRUD<Request>, ILogDAL
    {
        private readonly LogContext _ctx;
        private readonly IConfiguration _config;
        public LogDAL(LogContext ctx, IConfiguration config) : base(ctx)
        {
            _ctx = ctx;
            _config = config;
        }

        public int LogCount()
        {
            return  _ctx.Requests.Count();
        }

        public async Task<IEnumerable<Request>> Logs(int pageNumer)
        {
            return await _ctx.Requests.Include(m => m.CompanyService.Company).Include(m => m.CompanyService.Service)                     
                                .OrderByDescending(m => m.RequestDate)
                                .Skip((pageNumer-1)*10).Take(10)
                                .ToListAsync();                        
        }

        public async Task<IEnumerable<LogChartDTO>> LogChartInfo()
        {
            using (SqlConnection conn = new SqlConnection(_config.GetSection("ConnectionStrings:LogDB").Value))
            {
                IEnumerable<LogChartDTO> logChartDTO =  await conn.QueryAsync<LogChartDTO>("SP_LogChartInfo", commandType: CommandType.StoredProcedure);
                return logChartDTO;
            }
        }

        public async Task<Request> LogIO(int requestId)
        {
            return await _ctx.Requests.Include(m => m.RequestBody).FirstOrDefaultAsync(m => m.RequestId == requestId);
        }
    }
}
