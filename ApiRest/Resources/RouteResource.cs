using ApiRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiRest.Resources
{
    public class RouteResource
    {
        public int Id { get; set; }
        public int CreatorId { get; set; }
        public LocationResource Start { get; set; }
        public LocationResource Finish { get; set; }
        public int CarId { get; set; }
        public ICollection<UserResource> Ocupantes { get; set; }

    }
}