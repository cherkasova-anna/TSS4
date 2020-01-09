using System;
using System.Linq;
using System.Net;
using NUnit.Framework;
using WireMock.Matchers;
using WireMock.Server;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;


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

        public void Stop()
        {
            Stub.Stop();
        }
    }
}
