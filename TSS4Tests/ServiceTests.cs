using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using System.Net;
using System.IO;
using System.Net.NetworkInformation;
using TSS4.Service;
using TSS4.Repository;
using TSS4.Views;

namespace TSS4Tests.Tests
{
    [TestFixture]
    public class ServiceTests
    {
       
        [Test]
        public void CreateServiceTest()
        {
            UserService serv = new UserService(new UserRepository(""));
            Assert.IsNotNull(serv.rep);
        }

        [Test]
        public void ProcessServiceTest()
        {
            UserService serv = new UserService(new UserRepository(""));

            serv.rep.User = new User()
            {
                Login = "anna",
                Url = "url",
                Public_repos = 0
            };

            string result = serv.Process();
            string expected = "User: anna has 0 public repositories. The work may be better!";
            Assert.AreEqual(result, expected);

            serv.rep.User = new User()
            {
                Login = "olga",
                Url = "url",
                Public_repos = 8
            };

            result = serv.Process();
            expected = "User: olga has 8 public repositories. The work is rather good!";
            Assert.AreEqual(result, expected);

            serv.rep.User = new User()
            {
                Login = "programmer",
                Url = "url",
                Public_repos = 20
            };

            result = serv.Process();
            expected = "User: programmer has 20 public repositories. What`s a wonderful work!";
            Assert.AreEqual(result, expected);
        }
    }
}
