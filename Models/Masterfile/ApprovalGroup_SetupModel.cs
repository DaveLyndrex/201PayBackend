using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Models.Masterfile
{
    public class ApprovalGroup_SetupModel
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public string Layer { get; set; }
        public string Type { get; set; }
        public string ApproverGroup { get; set; }
        public string FormID { get; set; }
        public string LeaveTypeID { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}