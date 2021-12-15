using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace BackEnd.Models
{
    public class KioskShiftModel
    {
        public int ID { get; set; }
        public int EmpID { get; set; }
        public int RequestID { get; set; }
        public int FormID { get; set; }
        public string Form { get; set; }
        public int RequestEmpID { get; set; }

        public DateTime Date { get; set; }
        public DateTime CreatedDate { get; set; }

        public string Shift { get; set; }
        public string Reason { get; set; }
        public string Requester { get; set; }
        public string CreatedBy { get; set; }
        public string Status { get; set; }
    }
}