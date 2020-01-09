using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using System.Net;
using System.IO;
using System.Net.NetworkInformation;
using TSS4;
using TSS4.Repository;
using TSS4.Views;
using TSS4.Service;

namespace TSS4Tests.Tests
{

    [TestFixture]
    public class UserServiceRepositoryTestsMock
    {
        private MockServer Mock { get; set; }
        private bool Started { get; set; } = false;

        [SetUp]
        public void SetUpWireMock()
        {
            if (!Started)
            {
                Mock = new MockServer();
                Mock.Start("5001");
                Started = true;
            }
        }

        [Test]
        public void ServiceRepositoryMock()
        {
            Mock.StubUsers("anna-cherkasova", "https://api.github.com/users/anna-cherkasova", 0, "users/anna-cherkasova");
            Mock.StubUsers("WireMock-Net", "https://api.github.com/users/WireMock-Net", 5, "users/WireMock-Net");           

            UserService serv = new UserService(new UserRepository(Mock.BaseUrl));


            string result = serv.CheckUserWork("anna-cherkasova");
            string expected = "User: anna-cherkasova has 0 public repositories. The work may be better!";
            Assert.AreEqual(result, expected);



            result = serv.CheckUserWork("WireMock-Net");
            expected = "User: WireMock-Net has 5 public repositories. The work is rather good!";
            Assert.AreEqual(result, expected);



            result = serv.CheckUserWork("programmer");
            expected = "";
            Assert.AreEqual(result, expected);

            Mock.Stop();
        }
               
    }
}
