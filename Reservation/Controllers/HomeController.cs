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
using Reservation.Models;

namespace Reservation.Controllers
{   
    //[Authorize]
    public class HomeController : Controller
    {

        [HttpGet]
        //[AllowAnonymous]
        public IActionResult Login()
        {
            return View(new LoginModel());
        }

        [HttpPost]
        //[AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var principal = GetPrincipal(model);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToAction("Index", "Home");
        }

        ClaimsPrincipal GetPrincipal(LoginModel model)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, model.Login)
            };

            var identity = new ClaimsIdentity(claims,
                "ApplicationCookie",                    
                ClaimsIdentity.DefaultNameClaimType,    //Ключ который будет использоваться для определении имени пользователя
                ClaimsIdentity.DefaultRoleClaimType);   //Ключ который будет использоваться для определении роли пользователя

            return new ClaimsPrincipal(identity);
        }

        //[Authorize]
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

        //[Authorize]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
    }
}
