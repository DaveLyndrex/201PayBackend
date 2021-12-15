using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Models
{
    public class JobLevelSetup_Model
    {
        public int ID { get; set; }
        public string JobLevel { get; set; }
        public int Level { get; set; }
        public string EffectiveStartDate { get; set; }
        public string EffectiveEndDate { get; set; }
        public string SetCode { get; set; }
        public string ActiveStatus { get; set; }
        public string FullPartTime { get; set; }
        public string JobFunctionCode { get; set; }
        public string RegularTemporary { get; set; }
        public string BenchmarkJobCode { get; set; }
        public string ProgressionJobCode { get; set; }
        public string ApprovalAuthority { get; set; }
        public string ActionReasonCode { get; set; }
        public string ValidGradeEffectiveStartDate { get; set; }
        public string ValidGradeEffectiveEndDate { get; set; }
        public string GradeCode { get; set; }
        public string DateEvaluated { get; set; }
        public string EvaluationSystem { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string SourceSystemOwner { get; set; }
        public string SourceSystemID { get; set; }
    }
}