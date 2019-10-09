using System.Data.Entity;

namespace ApiRest.Models
{

    public class UserContext : DbContext
    {
        public UserContext() : base("name=ezcarConnectionString")
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
    }
}