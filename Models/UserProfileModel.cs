using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Models
{
    public class UserProfileModel
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Username { get; set; }
        public string LastName { get; set; }
        public string EmployeeIDNo { get; set; }
        public string DateOfBirth { get; set; }
        public string Email { get; set; }
    }
}