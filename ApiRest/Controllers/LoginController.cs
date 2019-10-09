using ApiRest.Models;
using ApiRest.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ApiRest.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [AllowAnonymous]
    [Route("")]
    public class LoginController : ApiController
    {

        private UserContext usercntxt = new UserContext();

        [Route("login")]
        public IHttpActionResult Login(LoginReq req)
        {
            if (req == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            if (CheckUser(req))
            {
                string token = TokenGenerator.GenerateTokenJwt(req.Email);
                return Ok(token);
            }
            else
            {
                return Unauthorized();
            }
        }

        [Route("register")]
        public IHttpActionResult Register([FromBody]User user)
        {
            if (!UserExist(user))
            {
                usercntxt.Users.Add(user);
                usercntxt.SaveChanges();
                string token = TokenGenerator.GenerateTokenJwt(user.Email);
                return Ok(token);
            }
            else
            {
                return Conflict();
            }
        }

        private bool CheckUser(LoginReq req)
        {
            return usercntxt.Users.Where(u => u.Email == req.Email && u.Pass == req.Pass).Count() > 0;
        }

        private bool UserExist(User user)
        {
            return (usercntxt.Users.FirstOrDefault(u => u.Email == user.Email) != null);
        }
    }
}