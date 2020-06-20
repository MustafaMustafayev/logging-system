using AutoMapper;
using LogSystem.DAL.AdminDAL.LogRepoDAL;
using LogSystem.DTO.AdminDTO.LogRepoDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LogSystem.BLL.AdminBLL.LogRepoBLL
{
    public class LogBLL : ILogBLL
    {
        private readonly ILogDAL _log;
        private readonly IMapper _mapper;
        public LogBLL(ILogDAL log, IMapper mapper)
        {
            _log = log;
            _mapper = mapper;
        }

        public async Task<LogsDTO> Logs(int pageNumer)
        {
            List<LogDTO> logDTO =  _mapper.Map<List<LogDTO>>(await _log.Logs(pageNumer));
            LogsDTO logs = new LogsDTO()
            {
                Logs = logDTO,
                RequestCount = _log.LogCount()
            };
            return logs;
        }

        public async Task<IEnumerable<LogChartDTO>> LogChartInfo()
        {
            return await _log.LogChartInfo();
        }

        public async Task<LogIODTO> LogIO(int requestId)
        {
            var logIODTO = _mapper.Map<LogIODTO>(await _log.LogIO(requestId));
            return logIODTO;
        }
    }
}
