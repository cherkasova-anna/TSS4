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

namespace TSS4Tests.Tests
{

    [TestFixture]
    public class UserRepositoryIsolationTests
    {
        private  MockServer Mock { get; set; }
        private bool Started { get; set; } = false;

        [SetUp]
        public void SetUpWireMock()
        {
            if(!Started)
            {
                Mock = new MockServer();
                Mock.Start("5000");
                Started = true;
            }           
        }

        [Test]
        public void UserGetTest()
        {
            Mock.StubUsers("anna", "url", 0, "users/anna-cherkasova");
            UserRepository rep = new UserRepository(Mock.BaseUrl);
            int result = rep.Get("anna-cherkasova");
            Assert.AreEqual(result, 200);
            User user = new User()
            {
                Login = "anna",
                Url = "url",
                Public_repos = 0
            };
            Assert.AreEqual(rep.User.Login, user.Login);
            Assert.AreEqual(rep.User.Url, user.Url);
            Assert.AreEqual(rep.User.Public_repos, user.Public_repos);
        }

        [Test]
        public void UserGetFailTest()
        {
            Mock.StubUsers("anna", "url", 0, "users/aaa");
            UserRepository rep = new UserRepository(Mock.BaseUrl);
            int result = rep.Get("anna-cherkasova");
            Assert.AreEqual(result, 404);
            User user = new User()
            {
                Login = "anna",
                Url = "url",
                Public_repos = 0
            };
            Assert.IsNull(rep.User);
        }
    }
}
