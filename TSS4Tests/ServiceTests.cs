using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using System.Net;
using System.IO;
using System.Net.NetworkInformation;
using TSS4.Service;
using TSS4.Repository;

namespace TSS4Tests.Tests
{
    [TestFixture]
    public class ServiceTests
    {
       
        [Test]
        public void CreateServiceTest()
        {
            UserService serv = new UserService(new UserRepository());
            Assert.IsNotNull(serv.rep);
        }
    }
}
