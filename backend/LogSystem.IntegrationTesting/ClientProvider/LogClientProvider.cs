using LogSystem.Admin.API;
using LogSystem.IntegrationTesting.RequestConfig;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Net.Http;

namespace LogSystem.IntegrationTesting.ClientProvider
{
    public class LogClientProvider : IDisposable
    {
        private TestServer server;
        public HttpClient Client { get; private set; }

        public LogClientProvider()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            Client = server.CreateClient();
            Client.DefaultRequestHeaders.Add("Authorization", RequestHeader.Authorization);
        }

        public void Dispose()
        {
            server?.Dispose();
            Client?.Dispose();
        }
    }
}
