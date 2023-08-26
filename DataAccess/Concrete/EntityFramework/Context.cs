using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class MotelContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Motel;Trusted_Connection=true");
        }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<RoomImage> RoomImages { get; set; }

    }
}
