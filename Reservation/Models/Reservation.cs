using System;
using System.ComponentModel.DataAnnotations;

namespace Reservation.Models
{
    public class Reservation
    {
        [Required]
        public int Id { get; set; } 
        [Required]
        public DateTime TimeBooking { get; set; }
        public int Priority { get; set; }
        public string Booker { get; set; }
        public Reservation (int id, DateTime timeBooking, int priority, string booker) 
        {
            Id = id;
            TimeBooking = timeBooking;
            Priority = priority;
            Booker = booker;
        }
    }
}
