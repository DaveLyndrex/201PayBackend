using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*10/07/2021 CN CRUBIO*/

namespace BackEnd.Models
{
    public class TimeKeepingModel
    {
        public string Date { get; set; }
        public int ID { get; set; }
        public int EmpID { get; set; }
        public string DayType { get; set; }
        public string Shift { get; set; }
        public string In1 { get; set; }
        public string Out1 { get; set; }
        public string In2 { get; set; }
        public string Out2 { get; set; }
        public string RawDTR { get; set; }
        public string COA { get; set; }
        public string Leave { get; set; }
        public string Tardy1 { get; set; }
        public string Absent1 { get; set; }
        public string Undertime1 { get; set; }
        public string Tardy2 { get; set; }
        public string Absent2 { get; set; }
        public string Undertime2 { get; set; }
        public string ReqOT { get; set; }
        public string OTHrs { get; set; }
        public string OT { get; set; }
        public string ND { get; set; }
        public int Validate { get; set; }
        public Boolean Valid { get; set; }
        public string ModifiedBy { get; set; }
        public string PayrollGroup { get; set; }

    }
}