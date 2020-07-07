using LogSystem.Core.CoreDAL;
using LogSystem.DTO.AdminDTO.LogRepoDTO;
using LogSystem.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogSystem.DAL.AdminDAL.LogRepoDAL
{
    public interface ILogDAL : ICRUD<Request>
    {
        Task<IEnumerable<Request>> Logs(int pageNumer);
        int LogCount();
        Task<IEnumerable<LogChartDTO>> LogChartInfo();
        Task<Request> LogIO(int requestId);
    }
}
