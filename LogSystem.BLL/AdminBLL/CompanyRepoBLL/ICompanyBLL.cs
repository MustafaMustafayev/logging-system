using LogSystem.DTO.AdminDTO.CompanyRepoDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LogSystem.BLL.AdminBLL.CompanyRepoBLL
{
    public interface ICompanyBLL
    {
        Task<IEnumerable<CompaniesDTO>> Get();
        Task<CompaniesDTO> Get(int companyId);
        Task<IEnumerable<CompanyFilterDTO>> CompanyFilter();
        Task<CompaniesDTO> AddedOrUpdated(int companyId);
        Task<CompaniesDTO> Post(CompanyAddDTO companyAddDTO);
        Task<CompaniesDTO> Put(CompanyDTO companyUpdateDTO);
        Task<int> Delete(int companyId);
        Task<bool> CheckCompanyExist(int companyId);
    }
}
