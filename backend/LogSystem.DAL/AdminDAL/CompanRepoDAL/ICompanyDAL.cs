using LogSystem.Core.CoreDAL;
using LogSystem.Entities;
using System.Threading.Tasks;

namespace LogSystem.DAL.AdminDAL.CompanRepoDAL
{
    public interface ICompanyDAL : ICRUD<Company>
    {
        Task<bool> CheckCompanyExist(int companyId);
    }
}
