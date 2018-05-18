using System;
using System.ComponentModel.DataAnnotations;

namespace Reservation.Models
{
    public class MeetingRoom
    {
        [Required]
        public int Id { get; set; } 
        public string Name { get; set; }
        public int Capacity { get; set; }
    }
}
