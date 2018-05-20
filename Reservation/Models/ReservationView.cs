
using System;
using System.ComponentModel.DataAnnotations;

namespace Reservation.Models
{

    public class ReservationView
    {
        public ReservationView(Reservation reservation, MeetingRoom room, string priority)
        {
            Reservation = reservation;
            MeetingRoom = room;
            Priority = priority;
        }

        public Reservation Reservation { get; }
        public string Priority { get; }

        public MeetingRoom MeetingRoom{ get;  }

    }

}
