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

        public MeetingRoom (int id, string name, int capacity)
        {
            Id = id;
            Name = name;
            Capacity = capacity;
        }
    }
}
