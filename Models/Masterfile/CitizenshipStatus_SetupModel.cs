using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Models.Masterfile
{
    public class CitizenshipStatus_SetupModel
    {
        public int ID { get; set; }
        public string LegislationCode { get; set; }
        public string CitizenshipStatus { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string SourceSystemOwner { get; set; }
        public string SourceSystemID { get; set; }
    }
}