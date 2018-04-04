using System;
using System.ComponentModel.DataAnnotations;

namespace Reservation.Models
{
    public class Reservation
    {
        [Required]
        public int Id { get; set; } 
        [Required]
        public DateTime TimeBooking { get; set; }   // время бронирования
        public int Priority { get; set; }
        public string Booker { get; set; }          // бронировщик
    }
}
