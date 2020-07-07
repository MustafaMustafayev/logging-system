using FluentAssertions;
using LogSystem.DTO.AdminDTO.CompanyRepoDTO;
using LogSystem.IntegrationTesting.ClientProvider;
using LogSystem.IntegrationTesting.MemberData;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LogSystem.IntegrationTesting.IntegrationTests
{
    public class CompanyIntegrationTest
    {
        [Fact]
        [Trait("Company","List")]
        public async Task CompanyList()
        {
            using (var client = new LogClientProvider().Client)
            {
                var response = await client.GetAsync("/api/company");
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }

        [Theory]
        [Trait("Company", "ById")]
        [MemberData(nameof(CompanyMemberData.Get), MemberType = typeof(CompanyMemberData))]
        public async Task CompanyById(int companyId)
        {
            using (var client = new LogClientProvider().Client)
            {
                var response = await client.GetAsync(String.Format("/api/company/{0}", companyId));
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }

        [Fact]
        [Trait("Company", "Filter")]
        public async Task CompanyFilter()
        {
            using (var client = new LogClientProvider().Client)
            {
                var response = await client.GetAsync("/api/company/companyFilter");
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }

        [Theory]
        [Trait("Company", "Add")]
        [MemberData(nameof(CompanyMemberData.Post), MemberType = typeof(CompanyMemberData))]
        public async Task CompanyAdd(CompanyAddDTO companyAddDTO)
        {
            using (var client = new LogClientProvider().Client)
            {
                var response = await client.PostAsync("/api/company",
                                     new StringContent(JsonConvert.SerializeObject(companyAddDTO), Encoding.UTF8, "application/json"));
             
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }

        [Theory]
        [Trait("Company", "Update")]
        [MemberData(nameof(CompanyMemberData.Put), MemberType = typeof(CompanyMemberData))]
        public async Task CompanyUpdate(CompanyDTO companyDTO)
        {
            using (var client = new LogClientProvider().Client)
            {
                var response = await client.PutAsync("/api/company",
                                     new StringContent(JsonConvert.SerializeObject(companyDTO), Encoding.UTF8, "application/json"));

                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }

        [Theory]
        [Trait("Company", "Delete")]
        [MemberData(nameof(CompanyMemberData.Delete), MemberType = typeof(CompanyMemberData))]
        public async Task CompanyDelete(int companyId)
        {
            using (var client = new LogClientProvider().Client)
            {
                var response = await client.DeleteAsync(String.Format("/api/company/{0}", companyId));

                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }
    }
}
