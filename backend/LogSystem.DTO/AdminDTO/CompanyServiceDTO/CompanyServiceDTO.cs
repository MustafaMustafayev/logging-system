using LogSystem.DTO.AdminDTO.ServiceRepoDTO;

namespace LogSystem.DTO.AdminDTO.CompanyServiceDTO
{
    public class CompanyServiceDTO
    {
        public int CompanyServiceId { get; set; }
        public string SecretKey { get; set; }
        public string CompanyServiceDesc { get; set; }
        public ServiceDTO Service { get; set; }
    }
}
