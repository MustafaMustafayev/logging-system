using LogSystem.DTO.AdminDTO.LogRepoDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LogSystem.BLL.AdminBLL.LogRepoBLL
{
    public interface ILogBLL
    {
        Task<LogsDTO> Logs(int pageNumer);

        Task<IEnumerable<LogChartDTO>> LogChartInfo();
        Task<LogIODTO> LogIO(int requestId);
    }
}
