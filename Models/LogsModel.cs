using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Models
{
    public class LogsModel
    {
        public int ID { get; set; }

        // Access_Logs
        public string Username { get; set; }

        // Activity_Logs
        public int Action { get; set; }
        public string StoredProc { get; set; }

        // Change_logs 
        public string EmpID { get; set; }
        public string Table { get; set; }
        public string Column { get; set; }
        public int Row { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }

        public string IPAddress { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}