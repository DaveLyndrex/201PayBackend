using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// [10 / 12 / 2021 CN CRUBIO]

namespace BackEnd.Models
{
    public class LeaveBalancesModel
    {
        public int EmployeeIDNo { get; set; }
        public int EmpID { get; set; }
        public string LeaveType { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string CarriedOverExpiry { get; set; }
        public decimal ExpiredCarriedOver { get; set; }
        public decimal Beginning { get; set; }
        public decimal CarriedOver { get; set; }
        public decimal TotalBegCredits { get; set; }
        public decimal Approved { get; set; }
        public decimal Balance { get; set; }

    }
}