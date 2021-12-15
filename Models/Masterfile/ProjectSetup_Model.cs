using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Models
{
    public class ProjectSetup_Model
    {
        public int ID { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}