using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Models
{
    public class PayrollDeductionCode_SetupModel
    {
        public int ID { get; set; }
        public string DeductionCode { get; set; }
        public string DeductionName { get; set; }
        public string DeductionTypeID { get; set; }
        public string Priority { get; set; }
        public string OrderNo { get; set; }
        public string AccountID { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}