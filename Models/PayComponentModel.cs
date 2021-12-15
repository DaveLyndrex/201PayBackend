/*[10/07/2021] CN E.Patot*/

namespace BackEnd.Models
{
    public class PayComponentModel
    {
        public int ID { get; set; }
        public int EmpID { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string PayCodeID { get; set; }
        public string TypeID { get; set; }
        public string Amount { get; set; }
        public string PeriodID { get; set; }
        public string Year { get; set; }
        public string PayRateID { get; set; }
        public string Currency { get; set; }
        public string StartProcessPeriod { get; set; }
        public string Forex { get; set; } 
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}