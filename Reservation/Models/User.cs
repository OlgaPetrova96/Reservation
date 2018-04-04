using System;
using System.ComponentModel.DataAnnotations;

namespace Reservation.Models
{
    public class User
    {
        [Required]
        public int Id { get; set; } 
        public string Name { get; set; } 
    }
}
