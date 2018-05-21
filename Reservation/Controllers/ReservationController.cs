using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reservation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Reservation.Controllers
{
    [Authorize]
    public class ReservationController : Controller
    {
        private RoomContext db;

        public ReservationController(RoomContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index()
        {
            var reservations = await db.Reservations.ToArrayAsync();

            var reservationsView = reservations.Select(async x =>
            {
                var room = await db.MeetingRoom.FirstOrDefaultAsync(y => y.Id == x.RoomId);
                var priority = await db.Priority.FirstOrDefaultAsync(y => y.Id == x.Priority);
                if (room != null && priority != null)
                    return new ReservationView(x, room, priority.Value);
                else
                    return null;
            }).Where(x => x != null).Select(r => r.Result);



            return View(reservationsView);
        }


        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            ViewBag.Room = new SelectList(db.MeetingRoom, "Id", "Name");
            ViewBag.Priority = new SelectList(db.Priority, "Id", "Value");

            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(Models.Reservation reservation)
        {
            try
            {
                if (reservation.BeginTime < reservation.EndTime)
                {
                    reservation.Booker = User.Identity.Name;
                    await db.Reservations.AddAsync(reservation);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Fail");

                //  ViewBag.Priority = new SelectList(new List<Priority>{ Priority.High, Priority.Low, Priority.Middle});

            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            ViewBag.Room = new SelectList(db.MeetingRoom, "Id", "Name");
            ViewBag.Priority = new SelectList(db.Priority, "Id", "Value");
            Models.Reservation reservation = db.Reservations.Find(id);
            return View(reservation);
        }

        [HttpPost]
        public ActionResult Edit(Models.Reservation reservation)
        {
            if (reservation.BeginTime < reservation.EndTime)
            {
                reservation.Booker = User.Identity.Name;
                db.Entry(reservation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Fail");

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var res = await db.Reservations.FirstOrDefaultAsync(r => r.Id == id);
                db.Reservations.Remove(res);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Fail()
        {
            return View();
        }
    }
}