using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reservation.Models;

namespace Reservation.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private RoomContext db;

        public HomeController(RoomContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index()
        {
            var reservation = await db.Reservations.Where(x => x.Booker == User.Identity.Name).ToArrayAsync();
            var rooms = reservation.Select(async x => await db.MeetingRoom.FirstOrDefaultAsync(y => y.Id == x.RoomId))
                .Select(t => t.Result.Name);
            return View(reservation);
        }

        public IActionResult Reservation()
        {
             return RedirectToAction("Index", "Resevation"); ;
        }
    } 
}
