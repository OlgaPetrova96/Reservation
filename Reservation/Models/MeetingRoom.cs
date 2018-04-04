using System;
using System.ComponentModel.DataAnnotations;

namespace Reservation.Models
{
    public class MeetingRoom                // уж сорян, но так переводчик сказал
    {
        [Required]
        public int Id { get; set; } 
        public string Name { get; set; }
        [Range(1, 60)]                      // просто так сделала ограничение на вместимость, по сути этого можно и не делать
        public int Capacity { get; set; }   // вместимость
    }
}
