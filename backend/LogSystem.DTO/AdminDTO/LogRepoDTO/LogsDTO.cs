using System;
using System.Collections.Generic;
using System.Text;

namespace LogSystem.DTO.AdminDTO.LogRepoDTO
{
    public class LogsDTO
    {
        public int RequestCount { get; set; }
        public IEnumerable<LogDTO> Logs { get; set; }
    }
}
