using LogSystem.DTO.AdminDTO.CompanyRepoDTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LogSystem.IntegrationTesting.MemberData
{
    public class CompanyMemberData : IEnumerable<object[]>
    {
        public static IEnumerable<object[]> Get()
        {
            int companyId = 2;
            yield return new object[] { companyId };
        }

        public static IEnumerable<object[]> Post()
        {
            CompanyAddDTO companyAddDTO = new CompanyAddDTO()
            {
                CompanyAbbr = "test42",
                CompanyName = "test432",
                CompanyDesc = "test2"
            };
            yield return new object[] { companyAddDTO };
        }

        public static IEnumerable<object[]> Put()
        {
            CompanyDTO companyDTO = new CompanyDTO()
            {
                CompanyId = 3,
                CompanyAbbr = "updated abbr",
                CompanyName = "updated name",
                CompanyDesc = "updated desc"
            };
            yield return new object[] { companyDTO };
        }

        public static IEnumerable<object[]> Delete()
        {
            int companyId = 2;
            yield return new object[] { companyId };
        }

        public IEnumerator<object[]> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
