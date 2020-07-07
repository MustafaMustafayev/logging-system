using AutoMapper;
using LogSystem.DAL.AdminDAL.CompanRepoDAL;
using LogSystem.DTO.AdminDTO.CompanyRepoDTO;
using LogSystem.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LogSystem.BLL.AdminBLL.CompanyRepoBLL
{
    public class CompanyBLL : ICompanyBLL
    {
        private readonly ICompanyDAL _company;
        private readonly IMapper _mapper;
        public CompanyBLL(ICompanyDAL company, IMapper mapper)
        {
            _company = company;
            _mapper = mapper;
        }

        public async Task<CompaniesDTO> AddedOrUpdated(int companyId)
        {
            return _mapper.Map<CompaniesDTO>(await _company.Get(m => m.CompanyId == companyId));
        }

        public async Task<IEnumerable<CompaniesDTO>> Get()
        {
            return _mapper.Map<IEnumerable<CompaniesDTO>>(await _company.GetList());
        }

        public async Task<CompaniesDTO> Get(int companyId)
        {
            return _mapper.Map<CompaniesDTO>(await _company.Get(m => m.CompanyId == companyId));
        }

        public async Task<CompaniesDTO> Post(CompanyAddDTO companyAddDTO)
        {
            Company company = _mapper.Map<Company>(companyAddDTO);
            company.CreatedDate = DateTime.Now;
            Company addedCompany = await _company.Add(company);
            return await AddedOrUpdated(addedCompany.CompanyId);
        }

        public async Task<bool> CheckCompanyExist(int companyId)
        {
            return await _company.CheckCompanyExist(companyId);
        }

        public async Task<CompaniesDTO> Put(CompanyDTO companyUpdateDTO)
        {
            Company company = _mapper.Map<Company>(companyUpdateDTO);
            company.UpdatedDate = DateTime.Now;
            Company updatedCompany = await _company.Update(company);
            return await AddedOrUpdated(updatedCompany.CompanyId);
        }

        public async Task<int> Delete(int companyId)
        {
            Company company = await _company.Get(m => m.CompanyId == companyId);
            company.DeletedDate = DateTime.Now;
            Company deletedCompany = await _company.Update(company);
            return deletedCompany.CompanyId;
        }

        public async Task<IEnumerable<CompanyFilterDTO>> CompanyFilter()
        {
            return _mapper.Map<IEnumerable<CompanyFilterDTO>>(await _company.GetList());
        }
    }
}
