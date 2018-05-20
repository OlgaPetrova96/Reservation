using System;
using System.ComponentModel.DataAnnotations;

namespace Reservation.Models
{
    public class MeetingRoom
    {
        [Required]
        public int Id { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Количество человек")]
        public int Capacity { get; set; }
    }
}
