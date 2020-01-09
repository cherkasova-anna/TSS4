using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSS4.Views;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace TSS4.Repository
{
    public class MockUserRepository : IUserRepository
    {
        public User User { get; set; }
        public string BaseUrl { get; set; }

        public MockUserRepository(string baseUrl)
        {
            BaseUrl = baseUrl;
        }

        public int Get(string param)
        {
            switch (param)
            {
                case "anna-cherkasova":
                    User = new User()
                    {
                        Login = "anna-cherkasova",
                        Url = "https://api.github.com/users/anna-cherkasova",
                        Public_repos = 0
                    };
                    return 200;
                case "WireMock-Net":
                    User = new User()
                    {
                        Login = "WireMock-Net",
                        Url = "https://api.github.com/users/WireMock-Net",
                        Public_repos = 5
                    };
                    return 200;
                default:
                    return 404;
            }
        }
    }
}
