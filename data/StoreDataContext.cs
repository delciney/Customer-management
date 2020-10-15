using Microsoft.EntityFrameworkCore;
using CustomerManagement.Data.Maps;
using CustomerManagement.Models;

namespace CustomerManagement.Data
{
    public class StoreDataContext : DbContext
    {
        public DbSet<LivingRoom> LivingRooms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=dbcustomer;User ID=SA;Password=1q2w3e%&");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BookingMap());
            builder.ApplyConfiguration(new LivingRoomMap());
        }
    }
}