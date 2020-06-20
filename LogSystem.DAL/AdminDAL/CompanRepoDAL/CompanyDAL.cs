using LogSystem.Core.CoreDAL;
using LogSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogSystem.DAL.AdminDAL.CompanRepoDAL
{
    public class CompanyDAL : CRUD<Company>, ICompanyDAL
    {
        private readonly LogContext _ctx;
        public CompanyDAL(LogContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public async Task<bool> CheckCompanyExist(int companyId)
        {
            return await _ctx.Companies.AnyAsync(m => m.CompanyId == companyId);
        }
    }
}
