using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiRest.Models
{
    public class LoginReq
    {
        public string Email { get; set; }
        public string Pass { get; set; }
    }
}