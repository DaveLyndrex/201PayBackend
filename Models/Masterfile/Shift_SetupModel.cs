using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Models.Masterfile
{
    public class Shift_SetupModel
    {
        public int ID { get; set; }
        public string ShiftCode { get; set; }
        public string ShiftName { get; set; }
        public string In1 { get; set; }
        public string Out1 { get; set; }
        public double NumHrs1 { get; set; }
        public string In2 { get; set; }
        public string Out2 { get; set; }
        public double NumHrs2 { get; set; }
        public string OTStart { get; set; }
        public int MidRequired { get; set; }
        public double MaxOT { get; set; }
        public double MaxUndertime { get; set; }
        public double RoundedTo { get; set; }
        public double GracePeriodDaily { get; set; }
        public double GracePeriodWeekly { get; set; }
        public double GracePeriodSemiMonthly { get; set; }
        public double GracePeriodMonthly { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}