using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Reservation.Models;

namespace Reservation.Controllers
{
    public class AuthController : Controller
    {
        readonly Dictionary<string, string> _userData;

        public AuthController()
        {
            _userData = new Dictionary<string, string>
            {
                {"Olga", "pass"}
            };
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            //Проверяем что совпадает логин и пароль
            if (_userData.ContainsKey(model.Login) && _userData[model.Login] == model.Password)
            {
                // создаем один claim который содержит логин нашего пользователя
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, model.Login)
                };

                var id = new ClaimsIdentity(claims,
                    "ApplicationCookie",                    
                    ClaimsIdentity.DefaultNameClaimType,    
                    ClaimsIdentity.DefaultRoleClaimType);   // что делать с ролью пока не знаю

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));


                return RedirectToAction("Login", "Home");
            }
            ModelState.AddModelError("", "Некорректные логин и(или) пароль");

            return View(model);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Test()
        {
            return View((object)User.Identity.Name);
        }
    }
}
