using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Models.Masterfile
{
    public class Ethnicity_SetupModel
    {

        public int ID { get; set; }
        public int LegislationCode { get; set; }
        public int DeclarePersonNumber { get; set; }
        public string Ethnicity { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}