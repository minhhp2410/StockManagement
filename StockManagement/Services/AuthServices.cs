using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Services
{
    class AuthServices:Http
    {
        public string _login(UserLogin user)
        {

            return ((Model.GetToken)Post(env.authorizePath, user, typeof(UserLogin))).message;
        }
    }
}
