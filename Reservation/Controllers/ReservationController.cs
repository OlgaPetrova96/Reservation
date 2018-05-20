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
            var reservation = await db.Reservations.ToArrayAsync();

            var reservationView = reservation
                .Select(async x =>
                {
                    var t = await db.MeetingRoom.FirstOrDefaultAsync(y => y.Id == x.RoomId);
                    return new ReservationView(x, t);
                })
                .Select(r => r.Result);

            return View(reservationView);
        }


        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            ViewBag.RoomId = new SelectList( db.MeetingRoom.Select(r => r.Name));
            ViewBag.Priority = new SelectList(new List<Priority> { Priority.High, Priority.Low, Priority.Middle }, "Priority");
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(Models.Reservation reservation)
        {
            try
            {
              //  ViewBag.Priority = new SelectList(new List<Priority>{ Priority.High, Priority.Low, Priority.Middle});
                reservation.Booker = User.Identity.Name;
                await db.Reservations.AddAsync(reservation);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            ViewBag.RoomId = new SelectList( db.MeetingRoom.Select(r => r.Name));
            ViewBag.Priority = new SelectList(new List<Priority> { Priority.High, Priority.Low, Priority.Middle }, "Priority");
            Models.Reservation reservation = db.Reservations.Find(id);
            return View(reservation);
        }

        [HttpPost]
        public ActionResult Edit(Models.Reservation reservation)
        {
            db.Entry(reservation).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
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
    }
}