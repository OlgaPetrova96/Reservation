using System;
using System.ComponentModel.DataAnnotations;

namespace Reservation.Models
{
    public enum Priority
    {
        High = 1,
        Middle = 2,
        Low = 3
    }
    
    public class ReservationView
    {
        public ReservationView(Reservation reservation, MeetingRoom room)
        {
            Reservation = reservation;
            MeetingRoom = room;
        }

        public Reservation Reservation { get;  }

        public MeetingRoom MeetingRoom{ get;  }

    }
}