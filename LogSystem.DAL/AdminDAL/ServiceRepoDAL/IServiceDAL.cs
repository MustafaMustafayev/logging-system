using LogSystem.Core.CoreDAL;
using LogSystem.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LogSystem.DAL.AdminDAL.ServiceRepoDAL
{
    public interface IServiceDAL : ICRUD<Service>
    {
        Task<bool> CheckServiceExist(int serviceId);
    }
}
