using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Reservation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Reservation.Controllers
{
    public class RoomController : Controller
    {
        private RoomContext db;

        public RoomController(RoomContext context)
        {
            db = context;
        }


        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(MeetingRoom room)
        {
            try
            {
                await db.MeetingRoom.AddAsync(room);
                await db.SaveChangesAsync();
                return RedirectToAction("Done");
            }
            catch
            {
                return RedirectToAction("Fail");
            }
        }

        public IActionResult Done()
        {
            return View();
        }

        public IActionResult Fail()
        {
            return View();
        }
    }
}