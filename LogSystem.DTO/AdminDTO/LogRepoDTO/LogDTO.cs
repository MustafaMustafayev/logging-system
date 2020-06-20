using System;
using System.Collections.Generic;
using System.Text;

namespace LogSystem.DTO.AdminDTO.LogRepoDTO
{
    public class LogDTO
    {
        public int RequestId { get; set; }
        public string CompanyName { get; set; }
        public string ServiceName { get; set; }
        public string RequestDate { get; set; }
    }
}
