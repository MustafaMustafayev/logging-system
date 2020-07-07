using LogSystem.DTO.AdminDTO.CompanyRepoDTO;
using System;
using System.Collections;
using System.Collections.Generic;

namespace LogSystem.UnitTesting.MemberData
{
    public class CompanyMemberData : IEnumerable<object[]>
    {
        public static IEnumerable<object[]> Get()
        {
            int companyId = 1;
            yield return new object[] { companyId };
        }

        public static IEnumerable<object[]> Post()
        {
            CompanyAddDTO companyAddDTO = new CompanyAddDTO()
            {
                CompanyAbbr = "test",
                CompanyName = "test",
                CompanyDesc = "test"
            };
            yield return new object[] { companyAddDTO };
        }

        public static IEnumerable<object[]> Put()
        {
            CompanyDTO companyDTO = new CompanyDTO()
            {
                CompanyId = 1,
                CompanyAbbr = "updated abbr",
                CompanyName = "updated name",
                CompanyDesc = "updated desc"
            };
            yield return new object[] { companyDTO };
        }

        public static IEnumerable<object[]> Delete()
        {
            int companyId = 1;
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
