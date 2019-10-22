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

        // GET api/locations
        [HttpGet]
        [Route("locations")]
        public IEnumerable<LocationResource> GetLocations()
        {
            List<LocationResource> locationResList = new List<LocationResource>();
            foreach (Location l in usercntxt.Locations.ToList())
            {
                LocationResource lres = new LocationResource
                {
                    Id = l.LocationId,
                    Latitude = l.Latitude,
                    Longitude = l.Longitude,
                    LocationName = l.LocationName
                    
                };
                locationResList.Add(lres);
            }
            return locationResList;
        }

        [HttpGet]
        [Route("locations/{idLocation:int}")]
        public IHttpActionResult GetLocationById(int idLocation)
        {
            Location l = usercntxt.Locations.Find(idLocation);
            LocationResource lres = new LocationResource
            {
                Id = l.LocationId,
                Latitude = l.Latitude,
                Longitude = l.Longitude,
                LocationName = l.LocationName

            };
            return Ok(lres);
        }

        // GET api/cars
        [Route("cars")]
        public IEnumerable<CarResource> GetCars()
        {
            List<CarResource> carResList = new List<CarResource>();
            foreach (Car c in usercntxt.Cars.Include("User").ToList())
            {
                CarResource cres = new CarResource
                {
                    Id = c.CarId,
                    Brand = c.Brand,
                    Model = c.Model,
                    PropietaryId = c.User.UserId

                };
                carResList.Add(cres);
            }
            return carResList;
        }

        // GET api/routes
        [HttpGet]
        [Route("routes")]
        public IEnumerable<RouteResource> GetRoutes()
        {
            
            List<RouteResource> routeResList = new List<RouteResource>();
            foreach (Route r in usercntxt.Routes
                .Include("Propietary")
                .Include("Users")
                .Include("Car")
                .Include("StartPoint")
                .Include("FinishPoint")
                .ToList())
            {
                List<int> ocupantesIds = new List<int>();
                foreach(User u in r.Users)
                {
                    ocupantesIds.Add(u.UserId);
                }
                RouteResource rres = new RouteResource
                {
                    Id = r.RouteId,
                    CarId = r.Car.CarId,
                    CreatorId = r.Propietary.UserId,
                    StartLocationId = r.StartPoint.LocationId,
                    StartName = r.StartPoint.LocationName,
                    FinishLocationId = r.FinishPoint.LocationId,
                    FinishName = r.FinishPoint.LocationName,
                    Ocupantes = ocupantesIds,

                };
                routeResList.Add(rres);
            }
            return routeResList;
        }
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
                    LocationName = location.LocationName,
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
                List<int> ocupantes = new List<int>();
                foreach(User u in route.Users)
                {
                    ocupantes.Add(u.UserId);
                }
                routesResource.Add(new RouteResource
                {
                    Id = route.RouteId,
                    CarId = route.Car.CarId,
                    CreatorId = route.Propietary.UserId,
                    StartLocationId = route.StartPoint.LocationId,
                    FinishLocationId = route.FinishPoint.LocationId,
                    Ocupantes = ocupantes
                }) ;
            }
            return routesResource;
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
        public void PostRoute([FromBody]RouteResource routeRes, int idUser)
        {
            User propietary = usercntxt.Users.Find(idUser);
            List<User> routeUsers = new List<User>();
            foreach(int uId in routeRes.Ocupantes)
            {
                routeUsers.Add(usercntxt.Users.Find(uId));
            }

            Route route = new Route
            {
                Propietary = propietary,
                Car = usercntxt.Cars.Find(routeRes.CarId),
                StartPoint = usercntxt.Locations.Find(routeRes.StartLocationId),
                FinishPoint = usercntxt.Locations.Find(routeRes.FinishLocationId),
                Users = routeUsers
            };

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

        /*
         * PUT OPERATIONS 
         */

        //PUT api/routes/{id}
        [Route("routes/{idRoute:int}")]
        [HttpPut]
        public IHttpActionResult AddUserRoute([FromBody]int ur, int idRoute)
        {
            Route route = usercntxt.Routes.Include("Users").Where(r => r.RouteId == idRoute).FirstOrDefault();
            User userAdded = usercntxt.Users.Find(ur);
            route.Users.Add(userAdded);
            usercntxt.SaveChanges();
            return Ok();
        }

        private bool UserExist(User user)
        {
            return (usercntxt.Users.FirstOrDefault(u => u.Email == user.Email) != null);
        }
    }
}