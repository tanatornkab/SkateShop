using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkateShop.Domain;

namespace SkateShop.Data
{
    public class SkateboardContext : DbContext
    {
        public SkateboardContext(DbContextOptions<SkateboardContext> options)
        : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public DbSet<Bearing> Bearing { get; set; }
        public DbSet<Accessory> Accessory { get; set; }
        public DbSet<Wheel> Wheel { get; set; }
        public DbSet<Truck> Truck { get; set; }
        public DbSet<Griptape> GripTape { get; set; }
        public DbSet<Deck> Deck { get; set; }
        public DbSet<Complete> Complete { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder
        //        .UseLoggerFactory(ConsoleLoggerFactory)
        //        .UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = SkateboardData");
        //}
        //public static readonly ILoggerFactory ConsoleLoggerFactory
        //   = LoggerFactory.Create(builder =>
        //   {
        //       builder
        //           .AddFilter((category, level) =>
        //               category == DbLoggerCategory.Database.Command.Name
        //               && level == LogLevel.Information)
        //           .AddConsole();
        //   });

    }
}

