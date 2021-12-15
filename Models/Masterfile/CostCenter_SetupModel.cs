using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Models
{
    public class CostCenter_SetupModel
    {
        public int ID { get; set; }
        public string CostCenterCode { get; set; }
        public string CostCenterName { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}