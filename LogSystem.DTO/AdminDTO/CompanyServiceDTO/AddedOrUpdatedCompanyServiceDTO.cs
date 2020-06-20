using System;
using System.Collections.Generic;
using System.Text;

namespace LogSystem.DTO.AdminDTO.CompanyServiceDTO
{
    public class AddedOrUpdatedCompanyServiceDTO
    {
        public int CompanyId { get; set; }
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceUrl { get; set; }
        public string SecretKey { get; set; }
        public string CompanyServiceDesc { get; set; }
    }
}
