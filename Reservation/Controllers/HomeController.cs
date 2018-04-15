using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reservation.Models;

namespace Reservation.Controllers
{   
    //[Authorize]
    public class HomeController : Controller
    {
        //[Authorize(Policy = "login")]
        public IActionResult Index()
        {
            var rooms = new List<MeetingRoom>();
            rooms.Add(new MeetingRoom(1, "Room 1", 10));
            rooms.Add(new MeetingRoom(2, "Room 2", 10));
            rooms.Add(new MeetingRoom(3, "Room 3", 13));
            rooms.Add(new MeetingRoom(4, "Room 4", 10));
            rooms.Add(new MeetingRoom(5, "Room 5", 11));
            return View(rooms);
        }

        //[Authorize(Policy = "login")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        //[Authorize(Policy = "login")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
