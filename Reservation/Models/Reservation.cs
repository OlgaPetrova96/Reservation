using System;
using System.ComponentModel.DataAnnotations;

namespace Reservation.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int RoomId{ get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Priority { get; set; }
        public string Booker { get; set; }
        public string Description { get; set; }
      
    }
}
