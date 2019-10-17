using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ApiRest.Models
{
    public class UserContextInitializer<T> : DropCreateDatabaseAlways<UserContext>
    {
        protected override void Seed(UserContext context)
        {
            IList<User> populatedUsers = new List<User>();
            User u1 = new User() { Email = "manu@um.es", Name = "Manuel", LastName = "Moreno", Telf = "610840118", Pass = "1234" };
            User u2 = new User() { Email = "jan@um.es", Name = "Jan", LastName = "Perez", Telf = "676376621", Pass = "1234" };
            User u3 = new User() { Email = "jesus@um.es", Name = "Jesus", LastName = "Josejoaquin", Telf = "626389835", Pass = "1234" };
            populatedUsers.Add(u1);
            populatedUsers.Add(u2);
            populatedUsers.Add(u3);
            context.Users.AddRange(populatedUsers);

            IList<Car> populatedCars = new List<Car>();
            Car c1 = new Car() { Brand = "Renault", Model = "Laguna", User = u1};
            Car c2 = new Car() { Brand = "Renault", Model = "Scenic", User = u1 };
            Car c3 = new Car() { Brand = "Ferrari", Model = "Enzo", User = u2 };
            Car c4 = new Car() { Brand = "Volkswagen", Model = "Polo", User = u3 };
            Car c5 = new Car() { Brand = "Renault", Model = "Megane", User = u3 };
            populatedCars.Add(c1);
            populatedCars.Add(c2);
            populatedCars.Add(c3);
            populatedCars.Add(c4);
            populatedCars.Add(c5);
            context.Cars.AddRange(populatedCars);

            IList<Location> populatedLocation = new List<Location>();
            Location l1 = new Location() { Latitude = "69.9999", Longitude = "96.99999", User = u1 };
            Location l2 = new Location() { Latitude = "79.9999", Longitude = "16.99999", User = u1 };
            Location l3 = new Location() { Latitude = "89.9999", Longitude = "26.99999", User = u1 };
            Location l4 = new Location() { Latitude = "99.9999", Longitude = "36.99999", User = u2 };
            Location l5 = new Location() { Latitude = "19.9999", Longitude = "46.99999", User = u2 };
            populatedLocation.Add(l1);
            populatedLocation.Add(l2);
            populatedLocation.Add(l3);
            populatedLocation.Add(l4);
            populatedLocation.Add(l5);
            context.Locations.AddRange(populatedLocation);

            IList<Route> populatedRoute = new List<Route>();
            IList<User> routeUsers = new List<User>();
            routeUsers.Add(u3);
            routeUsers.Add(u2);
            Route r1 = new Route() { Propietary = u1, StartPoint = l1, FinishPoint = l2, Car = c1, Users = routeUsers };
            Route r2 = new Route() { Propietary = u2, StartPoint = l2, FinishPoint = l3, Car = c3, Users = routeUsers };
            populatedRoute.Add(r1);
            populatedRoute.Add(r2);
            context.Routes.AddRange(populatedRoute);

            base.Seed(context);
        }
    }
}