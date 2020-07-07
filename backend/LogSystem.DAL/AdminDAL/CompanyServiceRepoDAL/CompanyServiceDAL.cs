using AutoMapper;
using LogSystem.Core.CoreDAL;
using LogSystem.DTO.AdminDTO.CompanyServiceDTO;
using LogSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogSystem.DAL.AdminDAL.CompanyServiceRepoDAL
{
    public class CompanyServiceDAL : CRUD<CompanyService>, ICompanyServiceDAL
    {
        private readonly LogContext _ctx;
        private readonly IMapper _mapper;
        public CompanyServiceDAL(LogContext ctx, IMapper mapper) : base(ctx)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<CompanyServicesDTO> AddedOrUpdatedCompanyService(int companyId, int serviceId)
        {
            return await _ctx.Companies.Include(m => m.CompanyServices)
                 .ThenInclude(x => x.Service)
                 .Where(m => m.CompanyId == companyId)
                 .Select(x => new CompanyServicesDTO
                 {
                     CompanyId = x.CompanyId,
                     CompanyServiceDTO = _mapper.Map<List<CompanyServiceDTO>>(x.CompanyServices.Where(m => m.ServiceId == serviceId).ToList())
                 }).FirstOrDefaultAsync();
        }

        public async Task<CompanyServicesDTO> CompanyServices(int companyId)
        {
            return await _ctx.Companies.Include(m => m.CompanyServices)
                             .ThenInclude(x => x.Service)
                             .Where(m => m.CompanyId == companyId)
                             .Select(x => new CompanyServicesDTO
                             {
                                 CompanyId = x.CompanyId,
                                 CompanyServiceDTO = _mapper.Map<List<CompanyServiceDTO>>(x.CompanyServices.ToList())
                             }).FirstOrDefaultAsync();
        }
    }
}
