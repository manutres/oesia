using System.Runtime.Serialization;

namespace ApiRest.Models
{
    public class Car
    {
        public int CarId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public User User { get; set; }
    }
}