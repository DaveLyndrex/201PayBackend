using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Models.Masterfile
{
    public class VisaPermitType_SetupModel
    {

        public int ID { get; set; }
        public string VisaPermitType { get; set; }
        public string LegislationCode { get; set; }
        public string CurrentVisaPermit{ get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}