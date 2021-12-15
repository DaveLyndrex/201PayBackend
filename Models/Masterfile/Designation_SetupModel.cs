using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackEnd.Models
{
    public class Designation_SetupModel
    {
        public int ID { get; set; }
        public string Designation { get; set; }
        public string PositionCode { get; set; }
        public string EffectiveStartDate { get; set; }
        public string EffectiveEndDate { get; set; }
        public string BusinessUnitName { get; set; }
        public string JobSetCode { get; set; }
        public string LocationSetCode { get; set; }
        public string EntryGradeSetCode { get; set; }
        public string ActiveStatus { get; set; }
        public string SupervisorPersonNumber { get; set; }
        public int HeadCount { get; set; }
        public int WorkingHours { get; set; }
        public string Frequency { get; set; }
        public string OverlapAllowedFlag { get; set; }
        public string SecurityClearance { get; set; }
        public string ActionReasonCode { get; set; }
        public string GradeSetCode { get; set; }
        public string GradeCode { get; set; }
        public int SequenceNumber { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string SourceSystemOwner { get; set; }
        public string SourceSystemID { get; set; }

    }
}