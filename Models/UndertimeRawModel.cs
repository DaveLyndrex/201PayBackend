using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Models
{
    public class UndertimeRawModel

    {
        public int ID { get; set; }
        public int EmpID { get; set; }
        public int RequestID { get; set; }
        public int Paid { get; set; }
        public string Date { get; set; }
        public string Time1 { get; set; }
        public string Time2 { get; set; }
        public int PeriodID { get; set; }
        public int Year { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}