using LogSystem.DTO.AdminDTO.CompanyServiceDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogSystem.BLL.AdminBLL.CompanyServiceRepoBLL
{
    public interface ICompanyServiceBLL
    {
        Task<IEnumerable<CompanyServicesDTO>> Get();
        Task<CompanyServicesDTO> Post(CompanyServiceAddDTO companyServiceAddDTO);
        Task<CompanyServicesDTO> CompanyServices(int companyId);
        Task<CompanyServicesDTO> AdddedOrUpdatedCompanyService(int companyId, int serviceId);
        Task<int> Delete(int companyServiceId);
        Task<CompanyServicesDTO> Put(CompanyServiceUpdateDTO companyServiceUpdateDTO);
    }
}
