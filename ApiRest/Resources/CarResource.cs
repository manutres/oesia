using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiRest.Resources
{
    public class CarResource
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int PropietaryId { get; set; }
    }
}