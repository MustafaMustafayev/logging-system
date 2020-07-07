using System;
using System.Collections.Generic;
using System.Text;

namespace LogSystem.DTO.AdminDTO.LogRepoDTO
{
    public class LogFilterDTO
    {
        public string SearchInput { get; set; }
        public string fromDate { get; set; }
        public string endDate { get; set; }
    }
}
