using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Models
{
    public class ApprovalWorkflowModel
    {
        public string Fullname { get; set; }
        public string Description { get; set; }

        public string Layer { get; set; }
        public string Type { get; set; }
    }
}