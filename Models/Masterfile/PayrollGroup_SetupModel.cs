using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Models
{
    public class PayrollGroup_SetupModel
    {
        public int ID { get; set; }
        public string PayrollGroup { get; set; }
        public int PayrollDays { get; set; }
        public int PayrollDaysOT { get; set; }
        public double DailyHours { get; set; }
        public int WTaxComputation { get; set; }
        public int SSSSchedule { get; set; }
        public int SSSComputation { get; set; }
        public int PAGSchedule { get; set; }
        public int PHILHEALTHSchedule { get; set; }
        public int PHILHEALTHComputation { get; set; }
        public int ThirteenthMo { get; set; }
        public int FourteenthMo { get; set; }
        public int FifteenthMo { get; set; }
        public int PayslipFormat { get; set; }
        public double MinTHPCT { get; set; }
        public double RiceAllowance { get; set; }
        public int RiceAllowSchedule { get; set; }
        public double MealAllowance { get; set; }
        public double TranspoAllowance { get; set; }
        public double NTaxMAMinWP { get; set; }
        public double UnionDue { get; set; }
        public int UnionDueSchedule { get; set; }
        public int DefaultShift { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}