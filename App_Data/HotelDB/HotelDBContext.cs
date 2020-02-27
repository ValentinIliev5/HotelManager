using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelManager.Models;
using System.Data.Entity;

namespace HotelManager.Models
{
    public class HotelDBContext : DbContext
    {
        public HotelDBContext() : base("name=DefaultConnection")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}