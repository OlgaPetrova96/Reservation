using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Reservation.Models
{
    public class LoginModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
