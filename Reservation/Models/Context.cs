using System;
using System.Collections.Generic;
using System.Web;
using Microsoft.EntityFrameworkCore;
 
namespace Reservation.Models
{
    public class RoomContext : DbContext
    {
        public DbSet<LoginModel> Logins { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public RoomContext(DbContextOptions<RoomContext> options)
            : base(options)
        {
        }
    }
}