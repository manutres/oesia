using ApiRest.Models;
using ApiRest.Resources;
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
        public IEnumerable<UserResource> GetUsers()
        {
            List<UserResource> userList = new List<UserResource>();
            foreach(User u in usercntxt.Users.ToList())
            {
                UserResource ur = new UserResource
                {
                    Email = u.Email,
                    Id = u.UserId,
                    LastName = u.LastName,
                    Name = u.Name
                };
                userList.Add(ur);
            }
            return userList;
        }

        // GET api/users/{id}
        [Route("users/{idUser:int}")]
        public User GetUser(int idUser)
        {
            return usercntxt.Users.Find(idUser);
        }

        // GET api/users/{id}/cars
        [Route("users/{idUser:int}/cars")]
        public IEnumerable<CarResource> GetCars(int idUser)
        {
            List<CarResource> carResources = new List<CarResource>();
            foreach(Car car in usercntxt.Cars
                .Include("User")
                .Where(c => c.User.UserId == idUser))
            {
                carResources.Add(new CarResource
                {
                    Id = car.CarId,
                    Brand = car.Brand,
                    Model = car.Model,
                    PropietaryId = car.User.UserId
                });
            }
            return carResources;
        }

        // GET api/users/{id}/cars/{id}
        [Route("users/{idUser:int}/cars/{idCar:int}")]
        public Car GetCar(int idCar)
        {
            return usercntxt.Cars.Find(idCar);
        }

        // GET api/users/{id}/locations
        [Route("users/{idUser:int}/locations")]
        public IEnumerable<LocationResource> GetLocations(int idUser)
        {
            List<LocationResource> locationResource = new List<LocationResource>();
            foreach (Location location in usercntxt.Locations
                .Include("User")
                .Where(l => l.User.UserId == idUser))
            {
                locationResource.Add(new LocationResource
                {
                    Id = location.LocationId,
                    Longitude = location.Longitude,
                    Latitude = location.Latitude,
                });
            }
            return locationResource;
        }

        // GET api/users/{id}/routes
        [Route("users/{idUser:int}/routes")]
        public IEnumerable<RouteResource> GetRoutes(int idUser)
        {
            List<RouteResource> routesResource = new List<RouteResource>();
            foreach (Route route in usercntxt.Routes
                .Include("Propietary")
                .Include("Users")
                .Include("Car")
                .Include("StartPoint")
                .Include("FinishPoint")
                .Where(r => r.Propietary.UserId == idUser))
            {
                List<UserResource> ocupantes = new List<UserResource>();
                foreach(User u in route.Users)
                {
                    ocupantes.Add(new UserResource
                    {
                        Email = u.Email,
                        Id = u.UserId,
                        LastName = u.LastName,
                        Name = u.Name
                    });
                }
                routesResource.Add(new RouteResource
                {
                    Id = route.RouteId,
                    CarId = route.Car.CarId,
                    CreatorId = route.Propietary.UserId,
                    Start = new LocationResource
                    {
                        Id = route.StartPoint.LocationId,
                        Latitude = route.StartPoint.Latitude,
                        Longitude = route.StartPoint.Longitude
                    },
                    Finish = new LocationResource
                    {
                        Id = route.FinishPoint.LocationId,
                        Latitude = route.FinishPoint.Latitude,
                        Longitude = route.FinishPoint.Longitude
                    },
                    Ocupantes = ocupantes
                }) ;
            }
            return routesResource;
        }

        // Este método es para debugueo, en principio no debería existir en la app
        // GET api/locations
        [Route("locations")]
        public IEnumerable<Location> GetAllLocations()
        {
            return usercntxt.Locations.ToList();
        }



        /*
         * POST OPERATIONS
         */

        // POST api/users/{id}/cars
        [Route("users/{idUser:int}/cars")]
        public void PostCar([FromBody]Car car, int idUser)
        {
            User user = usercntxt.Users.Find(idUser);
            car.User = user;
            usercntxt.Cars.Add(car);
            usercntxt.SaveChanges();
        }

        // POST api/users/{id}/locations
        [Route("users/{idUser:int}/locations")]
        public void PostLocation([FromBody]Location location, int idUser)
        {
            User user = usercntxt.Users.Find(idUser);
            location.User = user;
            usercntxt.Locations.Add(location);
            usercntxt.SaveChanges();
        }

        // POST api/users/{id}/routes
        [Route("users/{idUser:int}/routes")]
        public void PostRoute([FromBody]Route route, int idUser)
        {
            User user = usercntxt.Users.Find(idUser);
            route.Propietary = user;
            usercntxt.Routes.Add(route);
            usercntxt.SaveChanges();
        }

        // POST api/users
        [Route("users")]
        public IHttpActionResult Register([FromBody]User user)
        {
            if (!UserExist(user))
            {
                usercntxt.Users.Add(user);
                usercntxt.SaveChanges();
                return Ok(user);
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