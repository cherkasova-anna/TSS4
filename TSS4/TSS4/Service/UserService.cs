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

    }
}
