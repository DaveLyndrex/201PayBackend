using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Models
{
    public class CompanySetup_Model
    {
        public int ID { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string EffectiveStartDate { get; set; }
        public string EffectiveEndDate { get; set; }
        public string ClassificationName { get; set; }
        public string ClassificationEffectiveDate { get; set; }
        public string ExtraInfoEffectiveStartDate { get; set; }
        public string LegislationCode { get; set; }
        public string LeiInformationCategory { get; set; }
        public string SetCode { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string SourceSystemOwner { get; set; }
        public string SourceSystemID { get; set; }
    }
}