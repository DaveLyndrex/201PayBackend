using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


/*10/07/2021 CN CRUBIO*/
namespace BackEnd.Models
{
    public class PayrollPeriodModel
    {

        public string PayrollGroup { get; set; }
        public string ModifiedBy { get; set; }
        public string Location { get; set; }
        public string Employee { get; set; }
        public int EmployeeID { get; set; }
        public string ConcattedPeriod { get; set; }
        public string ButtonName { get; set; }
    }
}