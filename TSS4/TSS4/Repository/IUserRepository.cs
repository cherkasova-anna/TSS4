using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSS4.Views;

namespace TSS4.Repository
{
    public interface IUserRepository
    {
        User User { get; set; }
        string BaseUrl { get; set; }

        int Get(string param);
    }
}
