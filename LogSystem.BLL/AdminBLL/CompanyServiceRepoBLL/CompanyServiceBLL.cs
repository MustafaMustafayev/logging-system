using AutoMapper;
using LogSystem.DAL.AdminDAL.CompanyServiceRepoDAL;
using LogSystem.DTO.AdminDTO.CompanyServiceDTO;
using LogSystem.DTO.AdminDTO.ServiceRepoDTO;
using LogSystem.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LogSystem.BLL.AdminBLL.CompanyServiceRepoBLL
{
    public class CompanyServiceBLL : ICompanyServiceBLL
    {
        private readonly ICompanyServiceDAL _companyService;
        private readonly IMapper _mapper;
        public CompanyServiceBLL(ICompanyServiceDAL companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CompanyServicesDTO>> Get()
        {
            return null;
        }

        public async Task<CompanyServicesDTO> Post(CompanyServiceAddDTO companyServiceAddDTO)
        {
            CompanyService companyService = _mapper.Map<CompanyService>(companyServiceAddDTO);
            companyService.CreatedDate = DateTime.Now;
            CompanyService addedCompanyService = await _companyService.Add(companyService);
            return await _companyService.AddedOrUpdatedCompanyService(addedCompanyService.CompanyId, addedCompanyService.ServiceId);
        }

        public async Task<CompanyServicesDTO> CompanyServices(int companyId)
        {
            return  await _companyService.CompanyServices(companyId);
        }

        public async Task<CompanyServicesDTO> AdddedOrUpdatedCompanyService(int companyId, int serviceId)
        {
            return await _companyService.AddedOrUpdatedCompanyService(companyId, serviceId);
        }

        public async Task<int> Delete(int companyServiceId)
        {
            CompanyService companyService = await _companyService.Get(m => m.CompanyServiceId == companyServiceId);
            companyService.DeletedDate = DateTime.Now;
            CompanyService updatedCompanyService = await _companyService.Update(companyService);
            return updatedCompanyService.CompanyServiceId;
        }

        public async Task<CompanyServicesDTO> Put(CompanyServiceUpdateDTO companyServiceUpdateDTO)
        {
            CompanyService companyService = _mapper.Map<CompanyService>(companyServiceUpdateDTO);
            companyService.UpdatedDate = DateTime.Now;
            CompanyService addedCompanyService = await _companyService.Update(companyService);
            return await _companyService.AddedOrUpdatedCompanyService(addedCompanyService.CompanyId, addedCompanyService.ServiceId);
        }
    }
}
