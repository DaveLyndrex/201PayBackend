/*[10/05/2021] CN E.Patot*/

namespace BackEnd.Models
{
    public class PayrollDataModel
    {
        public int ID { get; set; }
        public int EmpID { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public decimal HDMFContribution { get; set; }
        public string PayrollGroupID { get; set; }
        public string TimekeepingID { get; set; }
        public string TaxStatusID { get; set; }
        public string PayFrequencyID { get; set; }
        public string ShiftSetID { get; set; }
        public string DMAccountID { get; set; }
        public string Remarks { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}