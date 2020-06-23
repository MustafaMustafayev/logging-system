using LogSystem.Admin.API.Controllers;
using LogSystem.BLL.AdminBLL.CompanyRepoBLL;
using LogSystem.DTO.AdminDTO.CompanyRepoDTO;
using LogSystem.DTO.AdminDTO.ServiceRepoDTO;
using LogSystem.UnitTesting.MemberData;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LogSystem.UnitTesting.UnitTests
{
    public class CompanyFixture : IDisposable
    {
        public Mock<ICompanyBLL> _mockBLL;
        public CompanyFixture()
        {
            _mockBLL = new Mock<ICompanyBLL>();
        }

        public void Dispose()
        {
            // Dispose unmanaged codes if exist
        }

        public CompanyController companyFixture => new CompanyController(_mockBLL.Object);
    }

    public class CompanyUnitTest : IClassFixture<CompanyFixture>
    {
        private readonly CompanyFixture _companyFixture;
        public CompanyUnitTest(CompanyFixture companyFixture)
        {
            _companyFixture = companyFixture;
        }

        [Fact]
        [Trait("Compant","List")]
        public async Task CompanyList()
        {
            var _company = _companyFixture.companyFixture;
            var actually = await _company.Get();
            Assert.True(actually is OkObjectResult);
        }

        [Theory]
        [Trait("Company", "ById")]
        [MemberData(nameof(CompanyMemberData.Get), MemberType = typeof(CompanyMemberData))]
        public async Task CompanyById(int companyId)
        {
            var _company = _companyFixture.companyFixture;
            var actually = await _company.Get(companyId);
            Assert.True(actually is OkObjectResult);
        }

        [Fact]
        [Trait("Company", "Filter")]
        public async Task CompanyFilter()
        {
            var _company = _companyFixture.companyFixture;
            var actually = await _company.CompanyFilter();
            Assert.True(actually is OkObjectResult);
        }

        [Theory]
        [Trait("Company","Add")]
        [MemberData(nameof(CompanyMemberData.Post), MemberType = typeof(CompanyMemberData))]
        public async Task CompanyAdd(CompanyAddDTO companyAddDTO)
        {
            var _company = _companyFixture.companyFixture;
            var actually = await _company.Post(companyAddDTO);
            Assert.True(actually is OkObjectResult);
        }

        [Theory]
        [Trait("Company", "Update")]
        [MemberData(nameof(CompanyMemberData.Put), MemberType = typeof(CompanyMemberData))]
        public async Task CompanyUpdate(CompanyDTO companyDTO)
        {
            _companyFixture._mockBLL.Setup(x => x.CheckCompanyExist(companyDTO.CompanyId))
                        .ReturnsAsync(true);

            var _company = _companyFixture.companyFixture;
            var actually = await _company.Put(companyDTO);
            Assert.True(actually is OkObjectResult);
        }

        [Theory]
        [Trait("Company","Delete")]
        [MemberData(nameof(CompanyMemberData.Delete), MemberType = typeof(CompanyMemberData))]
        public async Task CompanyDelete(int companyId)
        {
            _companyFixture._mockBLL.Setup(x => x.CheckCompanyExist(companyId))
                       .ReturnsAsync(true);

            var _company = _companyFixture.companyFixture;
            var actually = await _company.Delete(companyId);
            Assert.True(actually is OkObjectResult);
        }

    }
}
