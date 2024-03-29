﻿using System;
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
    public class UserServiceIsolationTests
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

            var result = serv.Process();
            var expected = "User: anna has 0 public repositories. The work may be better!";
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

        [Test]
        public void CheckUserWorkTestIsolation()
        {
            UserService serv = new UserService(new MockUserRepository(""));
            

            var result = serv.CheckUserWork("anna-cherkasova");
            var expected = "User: anna-cherkasova has 0 public repositories. The work may be better!";
            Assert.AreEqual(result, expected);

            

            result = serv.CheckUserWork("WireMock-Net");
            expected = "User: WireMock-Net has 5 public repositories. The work is rather good!";
            Assert.AreEqual(result, expected);

            

            result = serv.CheckUserWork("programmer");
            expected = "";
            Assert.AreEqual(result, expected);
        }
    }
}
