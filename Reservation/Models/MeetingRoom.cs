using System;
using System.ComponentModel.DataAnnotations;

namespace Reservation.Models
{
    public class MeetingRoom
    {
        [Required]
        public int Id { get; set; } 
        public string Name { get; set; }
        [Range(1, 60)]                      // просто так сделала ограничение на вместимость, по сути этого можно и не делать
        public int Capacity { get; set; }   // вместимость

        public MeetingRoom (int id, string name, int capacity) // временно (для меня)
        {
            Id = id;
            Name = name;
            Capacity = capacity;
        }
    }
}
