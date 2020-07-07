using System.Collections.Generic;

namespace LogSystem.DTO.AdminDTO.LogRepoDTO
{
    public class LogsDTO
    {
        public int RequestCount { get; set; }
        public IEnumerable<LogDTO> Logs { get; set; }
    }
}
