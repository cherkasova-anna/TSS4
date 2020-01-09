using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using System.Net;
using System.IO;
using System.Net.NetworkInformation;
using TSS4;

namespace TSS4Tests.Tests
{    
    [TestFixture]
    public class MockServerTest
    {
        private MockServer Mock { get; set; }     

        [Test]
        public void ConnectedToHostTest()
        {
            Mock = new MockServer();
            Mock.Start("5000");
            Mock.StubData();
            HttpWebRequest httpWebRequest = WebRequest.Create(Mock.BaseUrl) as HttpWebRequest;
            string res;
            string status;
            HttpWebResponse httpWebResponse;
            using (httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse)
            {
                using (Stream streamResponse = httpWebResponse.GetResponseStream())
                {
                      using (StreamReader read = new StreamReader(streamResponse))
                      {
                          res = read.ReadToEnd();
                          status = httpWebResponse.StatusCode.ToString();
                      }
                }
            }
            Assert.IsNotNull(httpWebResponse);
            Assert.AreEqual(res, "hello");
            Assert.AreEqual(status, "OK");
            Mock.Stop();
        }
    }
}
