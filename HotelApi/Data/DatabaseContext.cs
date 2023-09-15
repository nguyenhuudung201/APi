using HotelApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelApi.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
                : base(options)
        {

        }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("users");
        }
    }
}
