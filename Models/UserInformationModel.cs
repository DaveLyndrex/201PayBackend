using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Models
{
    public class UserInformationModel
    {
        public string EmployeeStatus { get; set; }
        public string CompanyName { get; set; }
        public string DepartmentName { get; set; }
        public string SubDept { get; set; }
        public string JobCategory { get; set; }
        public string GeoLoc { get; set; }
        public string WorkerType { get; set; }
        public string Description { get; set; }
        public string GroupMemberName { get; set; }

    }
}