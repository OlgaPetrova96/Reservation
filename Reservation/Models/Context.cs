using System;
using System.Collections.Generic;
using System.Web;
using Microsoft.EntityFrameworkCore;
 
namespace Reservation.Models
{
    public interface IEntryInDb
    {

    }
    public class RoomContext : DbContext
    {
        public DbSet<LoginModel> Logins { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<MeetingRoom> MeetingRoom { get; set; }

        public DbSet<Priority>  Priority { get; set; }


        public RoomContext(DbContextOptions<RoomContext> dbContextOptions) : base(dbContextOptions)
        {

        }
    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=roomsdb;Username=postgres;Password=cucucu29");
        }

    }
}