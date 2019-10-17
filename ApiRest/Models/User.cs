using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRest.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        [Index(IsUnique = true)]
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Telf { get; set; }
        public string Pass { get; set; }
        public ICollection<Car> Cars { get; set; }
        public ICollection<Location> Locations { get; set; }
        public ICollection<Route> Routes { get; set; }

    }
}