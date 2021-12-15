using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Models
{
    public class PayrollPeriod_SetupModel
    {
        public int ID { get; set; }
        public int PeriodID { get; set; }
        public int Year { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int StartDate_MonthID { get; set; }
        public int EndDate_MonthID { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public int PayrollGroupID { get; set; }
        public string PayrollGroup { get; set; }
        public string Description { get; set; }
        public string StartProcessPeriod { get; set; }
    }
}