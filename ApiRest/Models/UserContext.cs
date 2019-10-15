using System.Data.Entity;

namespace ApiRest.Models
{

    public class UserContext : DbContext
    {
        public UserContext() : base("name=ezcarConnectionString")
        {
            Database.SetInitializer<UserContext>(new DropCreateDatabaseIfModelChanges<UserContext>());
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Location> Locations { get; set; }
    }
}