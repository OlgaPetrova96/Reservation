using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reservation.Models;
using Microsoft.AspNetCore.Authorization;

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

        // GET: Reservation
        public async Task<IActionResult> Index()
        {
            return View(await db.Reservations.ToListAsync());
        }

        // GET: Reservation/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: Reservation/Create
        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reservation/Create
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(Models.Reservation reservation)
        {
            try
            {
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

        // GET: Reservation/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }

        // POST: Reservation/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Reservation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reservation/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}