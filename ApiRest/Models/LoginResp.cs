using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiRest.Models
{
    public class LoginResp
    {
        public string Token { get; set; }
        public User UserInfo { get; set; }
    }
}