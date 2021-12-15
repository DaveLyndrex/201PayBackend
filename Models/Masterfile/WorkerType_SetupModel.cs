using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Models
{
    public class WorkerType_SetupModel
    {
        public int ID { get; set; }
        public string WorkerType { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string SourceSystemOwner { get; set; }
        public string SourceSystemID { get; set; }
    }
}