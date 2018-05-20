using System;
using System.ComponentModel.DataAnnotations;

namespace Reservation.Models
{
    public class Reservation
    {
        [Display(Name = "Номер")] 
        public int Id { get; set; }
        [Display(Name = "Комната")] 
        public int RoomId{ get; set; } // вот тут Id на название переговорки поменяем
        [Display(Name = "Начало встречи")]
        public DateTime BeginTime { get; set; }
        [Display(Name = "Окончание встречи")]
        public DateTime EndTime { get; set; }
        [Display(Name = "Приоритет")]
        public int Priority { get; set; }
        [Display(Name = "Бронировщик")]
        public string Booker { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }
      
    }
}
