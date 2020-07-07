using LogSystem.Core.CoreDAL;
using LogSystem.Entities;
using System.Threading.Tasks;
using LogSystem.DTO.AdminDTO.CompanyServiceDTO;

namespace LogSystem.DAL.AdminDAL.CompanyServiceRepoDAL
{
    public interface ICompanyServiceDAL : ICRUD<CompanyService>
    {
        Task<CompanyServicesDTO> CompanyServices(int companyId);
        Task<CompanyServicesDTO> AddedOrUpdatedCompanyService(int companyId, int serviceId);
    }
}
