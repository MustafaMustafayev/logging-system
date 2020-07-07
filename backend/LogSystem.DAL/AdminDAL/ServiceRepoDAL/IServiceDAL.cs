using LogSystem.Core.CoreDAL;
using LogSystem.Entities;
using System.Threading.Tasks;

namespace LogSystem.DAL.AdminDAL.ServiceRepoDAL
{
    public interface IServiceDAL : ICRUD<Service>
    {
        Task<bool> CheckServiceExist(int serviceId);
    }
}
