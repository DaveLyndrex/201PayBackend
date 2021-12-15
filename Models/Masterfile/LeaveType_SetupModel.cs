using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Models
{
    public class LeaveType_SetupModel
    {
        public int ID { get; set; }
        public string LeaveType { get; set; }
        public int ChargeTo { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}