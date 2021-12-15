using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Models
{
    public class BusinessUnit_SetupModel
    {
        public int ID { get; set; }
        public string BUCode { get; set; }
        public string BUName { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}