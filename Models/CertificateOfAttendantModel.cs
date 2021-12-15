using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace BackEnd.Models
{
    public class CertificateOfAttendantModel
    {
        public int ID { get; set; }
        public int EmpID { get; set; }
        public int RequestID { get; set; }
        public int FormID { get; set; }
        public string Form { get; set; }
        public int RequestEmpID { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreatedDate { get; set; }
        public string StartTime { get; set; }
        public DateTime StartTimeDate { get; set; }
        public string EndTime { get; set; }

        public DateTime EndTimeDate { get; set; }

        public string StartTime2 { get; set; }

        public DateTime StartTimeDate2 { get; set; }
        public string EndTime2 { get; set; }

        public DateTime EndTimeDate2 { get; set; }
        public string Reason { get; set; }
        public string Requester { get; set; }
        public string CreatedBy { get; set; }
        public string Status { get; set; }
    }
}