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
    public class UserServiceRepositoryTests
    {
       
        [Test]
        public void ServiceRepositoryMock()
        {
            UserService serv = new UserService(new UserRepository("https://api.github.com/"));


            var result = serv.CheckUserWork("cherkasova-anna");
            var expected = "User: cherkasova-anna has 0 public repositories. The work may be better!";
            Assert.AreEqual(result, expected);



            result = serv.CheckUserWork("WireMock-Net");
            expected = "User: WireMock-Net has 5 public repositories. The work is rather good!";
            Assert.AreEqual(result, expected);



            result = serv.CheckUserWork("programmerrrrr");
            expected = "";
            Assert.AreEqual(result, expected);

        }

    }
}
