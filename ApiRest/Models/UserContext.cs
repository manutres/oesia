using System.Data.Entity;

namespace ApiRest.Models
{

    public class UserContext : DbContext
    {
        public UserContext() : base("name=ezcarConnectionString")
        {
            Database.SetInitializer<UserContext>(new UserContextInitializer<UserContext>());
            this.Configuration.LazyLoadingEnabled = false;
            Database.Initialize(true);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Route> Routes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Route>()
            .HasMany<User>(r => r.Users).WithMany(r => r.Routes)
            .Map(cs =>
            {
                cs.MapLeftKey("RouteId");
                cs.MapRightKey("UserId");
                cs.ToTable("RouteUser");
            });

        }
    }
}