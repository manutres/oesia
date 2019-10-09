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
    [Authorize]
    [RoutePrefix("api")]
    public class UsersController : ApiController
    {

        private UserContext usercntxt = new UserContext();

        /*
         * GET OPERATIONS
         */
        // GET api/users
        [HttpGet]
        [Route("users")]
        public IEnumerable<User> GetUsers()
        {
            return usercntxt.Users.ToList();
        }

        // GET api/users/{id}
        [Route("users/{idUser:int}")]
        public User GetUser(int idUser)
        {
            return usercntxt.Users.Find(idUser);
        }

        // GET api/users/{id}/cars
        [Route("users/{idUser:int}/cars")]
        public IEnumerable<Car> GetCars(int idUser)
        {
            return usercntxt.Cars
                .Where(c => c.User.UserId == idUser);
        }

        // GET api/users/{id}/cars/{id}
        [Route("users/{idUser:int}/cars/{idCar:int}")]
        public Car GetCar(int idCar)
        {
            return usercntxt.Cars.Find(idCar);
        }


        /*
         * POST OPERATIONS
         */

        // POST api/users/{id}/cars
        [Route("users/{idUser:int}/cars")]
        public void PostUser([FromBody]Car car, int idUser)
        {
            User user = usercntxt.Users.Find(idUser);
            car.User = user;
            usercntxt.Cars.Add(car);
            usercntxt.SaveChanges();
        }

        [Route("users")]
        public IHttpActionResult Register([FromBody]User user)
        {
            if (!UserExist(user))
            {
                usercntxt.Users.Add(user);
                usercntxt.SaveChanges();
                return Created<User>(Request.RequestUri + "/" + user.UserId, user);
            }
            else
            {
                return Conflict();
            }
        }

        private bool UserExist(User user)
        {
            return (usercntxt.Users.FirstOrDefault(u => u.Email == user.Email) != null);
        }
    }
}