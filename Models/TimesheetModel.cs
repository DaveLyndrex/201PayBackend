using System;


namespace BackEnd.Models
{
    public class TimesheetModel
    {
        public int ID { get; set; }
        public int EmpID { get; set; }
        public DateTime Date { get; set; }
        public string DayTypeCode { get; set; }
        public string ShiftCode { get; set; }
        public int In1 { get; set; }
        public int Out1 { get; set; }
        public int In2 { get; set; }
        public int Out2 { get; set; }
        public string RawDTR { get; set; }
        public string COA { get; set; }
        public string Leave { get; set; }
        public decimal Tardy1 { get; set; }
        public decimal Absent1 { get; set; }
        public decimal Undertime1 { get; set; }
        public decimal Tardy2 { get; set; }
        public decimal Absent2 { get; set; }
        public decimal Undertime2 { get; set; }
        public string RequestedOT { get; set; }
        public decimal RequestedOTHrs { get; set; }
        public decimal OTHrs { get; set; }
        public decimal OTHrsPaid { get; set; }
        public decimal NDHrs { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public int Validated { get; set; }
    }
}