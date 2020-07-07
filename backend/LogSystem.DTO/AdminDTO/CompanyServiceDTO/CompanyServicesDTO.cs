using LogSystem.DTO.AdminDTO.ServiceRepoDTO;
using LogSystem.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogSystem.DTO.AdminDTO.CompanyServiceDTO
{
    public class CompanyServicesDTO
    {
        public int CompanyId { get; set; }
        public List<CompanyServiceDTO> CompanyServiceDTO { get; set; }
    }
}
