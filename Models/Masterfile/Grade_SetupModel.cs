using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Models
{
    public class Grade_SetupModel
    {
        public int ID { get; set; }
        public string EffectiveStartDate { get; set; }
        public string EffectiveEndDate { get; set; }
        public string SetCode { get; set; }
        public string ActiveStatus { get; set; }
        public string GradeStepName { get; set; }
        public string GradeStepEffectiveDate { get; set; }
        public int GradeStepSequence { get; set; }
        public int CeilingStepFlag { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string SourceSystemOwner { get; set; }
        public string SourceSystemID { get; set; }
    }
}