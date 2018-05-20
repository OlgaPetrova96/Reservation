using System;
using System.ComponentModel.DataAnnotations;

namespace Reservation.Models
{
    public class Reservation
    {
        [Display(Name = "Номер")] 
        public int Id { get; set; }

        [Display(Name = "Комната")] 
        public int RoomId{ get; set; } 

        [Display(Name = "Начало встречи")]
        public DateTime BeginTime { get; set; }

        [Display(Name = "Окончание встречи")]
        public DateTime EndTime { get; set; }

        [Display(Name = "Приоритет")]
        //[Range(1, 3, ErrorMessage = "Недопустимый приоритет")]
        public int Priority { get; set; }

        [Display(Name = "Кто забронировал")]
        public string Booker { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }
      
    }
}
