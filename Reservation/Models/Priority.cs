using System.ComponentModel.DataAnnotations;


namespace Reservation.Models
{
    public class Priority
    {
        [Required]
        public int Id { get; set; }

        public string Value { get; set; }

    }
}
