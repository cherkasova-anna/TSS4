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
    public class UserRepository : IUserRepository
    {
        public User User { get; set; }

        public int Get (string baseUrl, string param)
        {
            string url = baseUrl + "users/" + param;
            HttpWebRequest httpWebRequest = WebRequest.Create(url) as HttpWebRequest;
            httpWebRequest.UserAgent = "Awersome-app";
            HttpWebResponse httpWebResponse = null; ;
            try
            {
                using (httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse)
                {
                    using (Stream streamResponse = httpWebResponse.GetResponseStream())
                    {
                        using (StreamReader read = new StreamReader(streamResponse))
                        {
                            string res = read.ReadToEnd();                           
                            User = JsonConvert.DeserializeObject<User>(res);
                            return (int)httpWebResponse.StatusCode;
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                HttpWebResponse httpResponse = (HttpWebResponse)ex.Response;
                return (int)httpResponse.StatusCode;
            }            
        }
    }
}
