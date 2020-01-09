using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSS4.Repository;

namespace TSS4.Service
{
    public class UserService
    {
        public IUserRepository rep;

        public UserService(IUserRepository rep)
        {
            this.rep = rep;
        }

        public string Process()
        {
            var res = $"User: {rep.User.Login} has {rep.User.Public_repos} public repositories.";
            if (rep.User.Public_repos < 5)
                return res + " The work may be better!";
            if (rep.User.Public_repos < 10)
                return res + " The work is rather good!";
            return res + " What`s a wonderful work!";
        }

    }
}
