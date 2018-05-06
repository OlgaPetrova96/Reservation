using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Reservation.Models
{
    public class LoginModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
