using System;
using System.Collections.Generic;
using System.Text;

namespace LogSystem.DTO.AdminDTO.CompanyRepoDTO
{
    public class CompaniesDTO
    {
        public int CompanyId { get; set; }
        public string CompanyAbbr { get; set; }
        public string CompanyName { get; set; }
        public string CompanyDesc { get; set; }
    }
}
