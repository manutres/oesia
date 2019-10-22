using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiRest.Models
{
    public class Route
    {
        public int RouteId { get; set; }
        public User Propietary { get; set; }
        public Location StartPoint { get; set; }
        public Location FinishPoint { get; set; }
        public Car Car { get; set; }
        public ICollection<User> Users {get; set; }

    }
}