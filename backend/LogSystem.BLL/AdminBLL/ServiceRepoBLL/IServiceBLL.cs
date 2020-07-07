using LogSystem.DTO.AdminDTO.ServiceRepoDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LogSystem.BLL.AdminBLL.ServiceRepoBLL
{
    public interface IServiceBLL
    {
        Task<IEnumerable<ServicesDTO>> Get();
        Task<ServiceDTO> Get(int serviceId);
        Task<ServicesDTO> AddedOrUpdatedService(int serviceId);
        Task<ServicesDTO> Post(ServiceAddDTO serviceAddDTO);
        Task<bool> CheckServiceExist(int serviceId);
        Task<ServicesDTO> Put(ServiceDTO serviceUpdateDTO);
        Task<int> Delete(int serviceId);
        Task<IEnumerable<ServiceFilterDTO>> ServiceFilter();
    }
}
