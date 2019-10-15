using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiRest.Models
{
    public class Route
    {
        public virtual User Creator { get; set; }
        public virtual Location StartPoint { get; set; }
        public virtual Location FinishPoint { get; set; }
        public virtual Car Car { get; set; }
        public virtual ICollection<User> Users {get; set; }
    }
}