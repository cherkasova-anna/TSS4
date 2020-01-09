using System;
using System.Linq;
using System.Net;
using NUnit.Framework;
using WireMock.Matchers;
using WireMock.Server;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using TSS4.Views;

namespace TSS4Tests
{
    class MockServer
    {
        public string BaseUrl { get; set; }
        public WireMockServer Stub;

       
        public void Start(string port)
        {
            BaseUrl = "http://localhost:" + port + "/";
            Stub = FluentMockServer.Start(new WireMock.Settings.FluentMockServerSettings
            {
                Urls = new[] { BaseUrl }
            });            
        }

        public void StubData()
        {
            Stub
               .Given(Request
               .Create()
               .WithUrl(BaseUrl)
               .UsingGet())
               .RespondWith(Response.Create().WithBody("hello"));
        }

        public void StubUsers(string login, string url, int public_repo, string request)
        {
            var user = new User()
            {
                Login = login,
                Url = url,
                Public_repos = public_repo
            };
            Stub
              .Given(Request
              .Create()
              .WithUrl(BaseUrl + request)
              .UsingGet())
              .RespondWith(Response.Create().WithBodyAsJson(user));
        }

        public void Stop()
        {
            Stub.Stop();
        }
    }
}
