using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Models
{
    public class LoginResponse
    {
        public string role { get; set; }
        public string message { get; set; }
        public string empId { get; set; }
    }
}