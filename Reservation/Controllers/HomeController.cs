﻿using System;
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
            var reservations = await db.Reservations.Where(x => x.Booker == User.Identity.Name).ToArrayAsync();

            var reservationsView = reservations.Select(async x =>
            {
                var room = await db.MeetingRoom.FirstOrDefaultAsync(y => y.Id == x.RoomId);
                var priority = await db.Priority.FirstOrDefaultAsync(y => y.Id == x.Priority);
                if (room != null && priority != null )
                    return new ReservationView(x, room, priority.Value);
                else
                    return null;
            }).Where(x => x != null).Select(r => r.Result);

            return View(reservationsView);
        }

        public IActionResult Reservation()
        {
             return RedirectToAction("Index", "Resevation");
        }
    } 
}
