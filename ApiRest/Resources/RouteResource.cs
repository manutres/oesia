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
        public int StartLocationId { get; set; }
        public string StartName { get; set; }
        public int FinishLocationId { get; set; }
        public string FinishName { get; set; }
        public int CarId { get; set; }
        public ICollection<int> Ocupantes { get; set; }
    }
}