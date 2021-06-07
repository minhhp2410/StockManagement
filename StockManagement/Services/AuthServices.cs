﻿using Newtonsoft.Json;
using StockManagement.Properties;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Services
{
    class AuthServices:Http
    {
        public bool _login(Model.User user)
        {
            var token = "";
            var roles = "";
            try
            {
                token = ((Model.GetToken)Post(env.authorizePath, user, typeof(UserLogin))).message;
                var handler = new JwtSecurityTokenHandler();
                var decodedToken = handler.ReadJwtToken(token);
                roles = decodedToken.Claims.ElementAt(2).Value;
                Settings.Default.token = token;
                Settings.Default.roles = roles;
                Settings.Default.Save();
            }
            catch
            {
                token = "";
            }
            if(string.IsNullOrEmpty(token))
            { return false; }return true;
        }
    }
}