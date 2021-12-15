using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Models
{
    public class PayrollPaycode_SetupModel
    {
        public int ID { get; set; }
        public string PayCode { get; set; }
        public string PayName { get; set; }
        public int PayTypeID { get; set; }
        public int PayRate { get; set; }
        public int OrderNo { get; set; }
        public int PhilHealth { get; set; }
        public int SSS { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public int AccountID { get; set; }
    }
}