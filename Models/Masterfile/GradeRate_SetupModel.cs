using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Models
{
    public class GradeRate_SetupModel
    {
        public int ID { get; set; }
        public string GradeRateName { get; set; }
        public string EffectiveStartDate { get; set; }
        public string EffectiveEndDate { get; set; }
        public string LegislativeDataGroup { get; set; }
        public string RateType { get; set; }
        public string CurrencyCode { get; set; }
        public string RateFrequency { get; set; }
        public int AnnualizationFactor { get; set; }
        public string ActiveStatus { get; set; }
        public int RateName { get; set; }
        public int MinAmount { get; set; }
        public int MaxAmount { get; set; }
        public int MidValueAmount { get; set; }
        public string SetCode { get; set; }
        public string GradeCode { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string SourceSystemOwner { get; set; }
        public string SourceSystemID { get; set; }
    }
}