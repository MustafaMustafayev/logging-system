using AutoMapper;
using LogSystem.DAL.AdminDAL.ServiceRepoDAL;
using LogSystem.DTO.AdminDTO.ServiceRepoDTO;
using LogSystem.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogSystem.BLL.AdminBLL.ServiceRepoBLL
{
    public class ServiceBLL : IServiceBLL
    {
        private readonly IServiceDAL _service;
        private readonly IMapper _mapper;
        public ServiceBLL(IServiceDAL service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<ServicesDTO> AddedOrUpdatedService(int serviceId)
        {
            return _mapper.Map<ServicesDTO>(await _service.Get(m => m.ServiceId == serviceId));
        }

        public async Task<bool> CheckServiceExist(int serviceId)
        {
            return await _service.CheckServiceExist(serviceId);
        }

        public async Task<int> Delete(int serviceId)
        {
            Service service = await _service.Get(m => m.ServiceId == serviceId);
            service.DeletedDate = DateTime.Now;
            Service deletedService = await _service.Update(service);
            return deletedService.ServiceId;
        }

        public async Task<IEnumerable<ServicesDTO>> Get()
        {
            return _mapper.Map<IEnumerable<ServicesDTO>>(await _service.GetList());
        }

        public async Task<ServiceDTO> Get(int serviceId)
        {
            return _mapper.Map<ServiceDTO>(await _service.Get(m => m.ServiceId == serviceId));
        }

        public async Task<ServicesDTO> Post(ServiceAddDTO serviceAddDTO)
        {
            Service service = _mapper.Map<Service>(serviceAddDTO);
            service.CreatedDate = DateTime.Now;
            Service addedService = await _service.Add(service);
            return await AddedOrUpdatedService(addedService.ServiceId);
        }

        public async Task<ServicesDTO> Put(ServiceDTO serviceUpdateDTO)
        {
            Service service = _mapper.Map<Service>(serviceUpdateDTO);
            service.UpdatedDate = DateTime.Now;
            Service updatedService = await _service.Update(service);
            return await AddedOrUpdatedService(updatedService.ServiceId);
        }

        public async Task<IEnumerable<ServiceFilterDTO>> ServiceFilter()
        {
            return _mapper.Map<IEnumerable<ServiceFilterDTO>>(await _service.GetList());
        }
    }
}
