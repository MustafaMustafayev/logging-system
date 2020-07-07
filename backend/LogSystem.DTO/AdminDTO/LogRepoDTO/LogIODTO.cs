using System;
using System.Collections.Generic;
using System.Text;

namespace LogSystem.DTO.AdminDTO.LogRepoDTO
{
    public class LogIODTO
    {
        public int RequestId { get; set; }
        public string Input { get; set; }
        public string Output { get; set; }
    }
}
